using Microsoft.EntityFrameworkCore.Migrations;

namespace MEU.web.Migrations
{
    public partial class R : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Statuses",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Voy_id",
                table: "Statuses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Statuses");

            migrationBuilder.DropColumn(
                name: "Voy_id",
                table: "Statuses");
        }
    }
}
