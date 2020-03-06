using Microsoft.EntityFrameworkCore.Migrations;

namespace MEU.web.Migrations
{
    public partial class newimgs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "News");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "NewImages");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "NewImages",
                nullable: true,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "News",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "NewImages",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "NewImages",
                nullable: false,
                defaultValue: "");
        }
    }
}
