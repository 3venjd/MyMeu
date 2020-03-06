using Microsoft.EntityFrameworkCore.Migrations;

namespace MEU.web.Migrations
{
    public partial class LineupToTerminal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineUps_Ports_PortId",
                table: "LineUps");

            migrationBuilder.RenameColumn(
                name: "PortId",
                table: "LineUps",
                newName: "TerminalId");

            migrationBuilder.RenameIndex(
                name: "IX_LineUps_PortId",
                table: "LineUps",
                newName: "IX_LineUps_TerminalId");

            migrationBuilder.AlterColumn<string>(
                name: "Usa_Phone",
                table: "Offices",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_LineUps_Terminals_TerminalId",
                table: "LineUps",
                column: "TerminalId",
                principalTable: "Terminals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineUps_Terminals_TerminalId",
                table: "LineUps");

            migrationBuilder.RenameColumn(
                name: "TerminalId",
                table: "LineUps",
                newName: "PortId");

            migrationBuilder.RenameIndex(
                name: "IX_LineUps_TerminalId",
                table: "LineUps",
                newName: "IX_LineUps_PortId");

            migrationBuilder.AlterColumn<string>(
                name: "Usa_Phone",
                table: "Offices",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LineUps_Ports_PortId",
                table: "LineUps",
                column: "PortId",
                principalTable: "Ports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
