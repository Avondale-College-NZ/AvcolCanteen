using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AvcolCanteen.Areas.Identity.Data;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var connectionString = builder.Configuration.GetConnectionString("AvcolCanteenContextConnection") ?? throw new InvalidOperationException("Connection string 'AvcolCanteenContextConnection' not found.");

        builder.Services.AddDbContext<AvcolCanteenContext>(options => options.UseSqlServer(connectionString));

        builder.Services.AddDefaultIdentity<AvcolCanteenUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<AvcolCanteenContext>();

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.MapRazorPages();

        using (var scope = app.Services.CreateScope())
        {
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var roles = new[] { "Admin", "Manager", "Member" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        using (var scope = app.Services.CreateScope())
        {
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AvcolCanteenUser>>();

            string firstname = "admin";
            string lastname = "admin";
            string email = "admin@admin.com";
            string password = "Test_12345";


            if(await userManager.FindByEmailAsync(email) == null)
            {
                var user = new AvcolCanteenUser();
                user.Email = email;
                user.UserName = email;
                user.FirstName = firstname;
                user.LastName = lastname;
                user.EmailConfirmed = true;

                await userManager.CreateAsync(user, password);

                await userManager.AddToRoleAsync(user, "Admin");
            }
        }

        app.Run();
    }
}