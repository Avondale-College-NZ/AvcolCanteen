using AvcolCanteen.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AvcolCanteen.Models;

namespace AvcolCanteen.Areas.Identity.Data;

public class AvcolCanteenContext : IdentityDbContext<AvcolCanteenUser>
{
    public AvcolCanteenContext(DbContextOptions<AvcolCanteenContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    public DbSet<AvcolCanteen.Models.Categories> Categories { get; set; } = default!;

    public DbSet<AvcolCanteen.Models.Products> Products { get; set; } = default!;

    public DbSet<AvcolCanteen.Models.Cart> Cart { get; set; } = default!;

    public DbSet<AvcolCanteen.Models.Orders> Orders { get; set; } = default!;

    public DbSet<AvcolCanteen.Models.Payment> Payment { get; set; } = default!;


}
