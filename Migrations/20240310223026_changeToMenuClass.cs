using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvcolCanteen.Migrations
{
    /// <inheritdoc />
    public partial class changeToMenuClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "MenuSpecial",
                table: "Menu",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MenuStock",
                table: "Menu",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MenuSpecial",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "MenuStock",
                table: "Menu");
        }
    }
}
