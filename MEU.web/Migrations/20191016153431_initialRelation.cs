using Microsoft.EntityFrameworkCore.Migrations;

namespace MEU.web.Migrations
{
    public partial class initialRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Voys",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Voys",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PortId",
                table: "Voys",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VesselId",
                table: "Voys",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VesselTypeId",
                table: "Vessels",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PortId",
                table: "Terminals",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VoyId",
                table: "Statuses",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PortId",
                table: "LineUps",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Holds",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AlertId",
                table: "Galleries",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NewId",
                table: "Galleries",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VoyId",
                table: "Galleries",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OfficeId",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Alerts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Voys_CompanyId",
                table: "Voys",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Voys_EmployeeId",
                table: "Voys",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Voys_PortId",
                table: "Voys",
                column: "PortId");

            migrationBuilder.CreateIndex(
                name: "IX_Voys_VesselId",
                table: "Voys",
                column: "VesselId");

            migrationBuilder.CreateIndex(
                name: "IX_Vessels_VesselTypeId",
                table: "Vessels",
                column: "VesselTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Terminals_PortId",
                table: "Terminals",
                column: "PortId");

            migrationBuilder.CreateIndex(
                name: "IX_Statuses_VoyId",
                table: "Statuses",
                column: "VoyId");

            migrationBuilder.CreateIndex(
                name: "IX_LineUps_PortId",
                table: "LineUps",
                column: "PortId");

            migrationBuilder.CreateIndex(
                name: "IX_Holds_StatusId",
                table: "Holds",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Galleries_AlertId",
                table: "Galleries",
                column: "AlertId");

            migrationBuilder.CreateIndex(
                name: "IX_Galleries_NewId",
                table: "Galleries",
                column: "NewId");

            migrationBuilder.CreateIndex(
                name: "IX_Galleries_VoyId",
                table: "Galleries",
                column: "VoyId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_OfficeId",
                table: "Employees",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CompanyId",
                table: "Clients",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Alerts_StatusId",
                table: "Alerts",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alerts_Statuses_StatusId",
                table: "Alerts",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Companies_CompanyId",
                table: "Clients",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Offices_OfficeId",
                table: "Employees",
                column: "OfficeId",
                principalTable: "Offices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Galleries_Alerts_AlertId",
                table: "Galleries",
                column: "AlertId",
                principalTable: "Alerts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Galleries_News_NewId",
                table: "Galleries",
                column: "NewId",
                principalTable: "News",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Galleries_Voys_VoyId",
                table: "Galleries",
                column: "VoyId",
                principalTable: "Voys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Holds_Statuses_StatusId",
                table: "Holds",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LineUps_Ports_PortId",
                table: "LineUps",
                column: "PortId",
                principalTable: "Ports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Statuses_Voys_VoyId",
                table: "Statuses",
                column: "VoyId",
                principalTable: "Voys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Terminals_Ports_PortId",
                table: "Terminals",
                column: "PortId",
                principalTable: "Ports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vessels_VesselTypes_VesselTypeId",
                table: "Vessels",
                column: "VesselTypeId",
                principalTable: "VesselTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Voys_Companies_CompanyId",
                table: "Voys",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Voys_Employees_EmployeeId",
                table: "Voys",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Voys_Ports_PortId",
                table: "Voys",
                column: "PortId",
                principalTable: "Ports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Voys_Vessels_VesselId",
                table: "Voys",
                column: "VesselId",
                principalTable: "Vessels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alerts_Statuses_StatusId",
                table: "Alerts");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Companies_CompanyId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Offices_OfficeId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Galleries_Alerts_AlertId",
                table: "Galleries");

            migrationBuilder.DropForeignKey(
                name: "FK_Galleries_News_NewId",
                table: "Galleries");

            migrationBuilder.DropForeignKey(
                name: "FK_Galleries_Voys_VoyId",
                table: "Galleries");

            migrationBuilder.DropForeignKey(
                name: "FK_Holds_Statuses_StatusId",
                table: "Holds");

            migrationBuilder.DropForeignKey(
                name: "FK_LineUps_Ports_PortId",
                table: "LineUps");

            migrationBuilder.DropForeignKey(
                name: "FK_Statuses_Voys_VoyId",
                table: "Statuses");

            migrationBuilder.DropForeignKey(
                name: "FK_Terminals_Ports_PortId",
                table: "Terminals");

            migrationBuilder.DropForeignKey(
                name: "FK_Vessels_VesselTypes_VesselTypeId",
                table: "Vessels");

            migrationBuilder.DropForeignKey(
                name: "FK_Voys_Companies_CompanyId",
                table: "Voys");

            migrationBuilder.DropForeignKey(
                name: "FK_Voys_Employees_EmployeeId",
                table: "Voys");

            migrationBuilder.DropForeignKey(
                name: "FK_Voys_Ports_PortId",
                table: "Voys");

            migrationBuilder.DropForeignKey(
                name: "FK_Voys_Vessels_VesselId",
                table: "Voys");

            migrationBuilder.DropIndex(
                name: "IX_Voys_CompanyId",
                table: "Voys");

            migrationBuilder.DropIndex(
                name: "IX_Voys_EmployeeId",
                table: "Voys");

            migrationBuilder.DropIndex(
                name: "IX_Voys_PortId",
                table: "Voys");

            migrationBuilder.DropIndex(
                name: "IX_Voys_VesselId",
                table: "Voys");

            migrationBuilder.DropIndex(
                name: "IX_Vessels_VesselTypeId",
                table: "Vessels");

            migrationBuilder.DropIndex(
                name: "IX_Terminals_PortId",
                table: "Terminals");

            migrationBuilder.DropIndex(
                name: "IX_Statuses_VoyId",
                table: "Statuses");

            migrationBuilder.DropIndex(
                name: "IX_LineUps_PortId",
                table: "LineUps");

            migrationBuilder.DropIndex(
                name: "IX_Holds_StatusId",
                table: "Holds");

            migrationBuilder.DropIndex(
                name: "IX_Galleries_AlertId",
                table: "Galleries");

            migrationBuilder.DropIndex(
                name: "IX_Galleries_NewId",
                table: "Galleries");

            migrationBuilder.DropIndex(
                name: "IX_Galleries_VoyId",
                table: "Galleries");

            migrationBuilder.DropIndex(
                name: "IX_Employees_OfficeId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Clients_CompanyId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Alerts_StatusId",
                table: "Alerts");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Voys");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Voys");

            migrationBuilder.DropColumn(
                name: "PortId",
                table: "Voys");

            migrationBuilder.DropColumn(
                name: "VesselId",
                table: "Voys");

            migrationBuilder.DropColumn(
                name: "VesselTypeId",
                table: "Vessels");

            migrationBuilder.DropColumn(
                name: "PortId",
                table: "Terminals");

            migrationBuilder.DropColumn(
                name: "VoyId",
                table: "Statuses");

            migrationBuilder.DropColumn(
                name: "PortId",
                table: "LineUps");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Holds");

            migrationBuilder.DropColumn(
                name: "AlertId",
                table: "Galleries");

            migrationBuilder.DropColumn(
                name: "NewId",
                table: "Galleries");

            migrationBuilder.DropColumn(
                name: "VoyId",
                table: "Galleries");

            migrationBuilder.DropColumn(
                name: "OfficeId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Alerts");
        }
    }
}
