using Microsoft.EntityFrameworkCore.Migrations;

namespace MEU.web.Migrations
{
    public partial class quitwebpageoffice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WebPage",
                table: "Offices");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WebPage",
                table: "Offices",
                nullable: false,
                defaultValue: "");
        }
    }
}
