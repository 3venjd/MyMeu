using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MEU.web.Migrations
{
    public partial class FirstDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alerts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Alert_Description = table.Column<string>(nullable: false),
                    Alert_Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alerts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 20, nullable: false),
                    LastName = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Country = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Cargo = table.Column<string>(nullable: false),
                    Mobile = table.Column<string>(nullable: false),
                    Direct_Cellphone = table.Column<string>(nullable: false),
                    Skype = table.Column<string>(nullable: false),
                    Direct_Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Galleries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Galleries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Holds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Hold_Number = table.Column<int>(maxLength: 2, nullable: false),
                    Actual_Quantity = table.Column<double>(nullable: false),
                    Max_Quantity = table.Column<double>(nullable: false),
                    Is_Full = table.Column<bool>(nullable: false),
                    Is_Empty = table.Column<bool>(nullable: false),
                    First_Charge = table.Column<DateTime>(nullable: false),
                    Last_Charge = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LineUps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Vessel = table.Column<string>(maxLength: 20, nullable: false),
                    Eta = table.Column<DateTime>(nullable: false),
                    Etb = table.Column<DateTime>(nullable: false),
                    Etc = table.Column<DateTime>(nullable: false),
                    Etd = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    Cargo = table.Column<string>(nullable: false),
                    Quantity = table.Column<string>(nullable: false),
                    Laycan = table.Column<string>(nullable: false),
                    Pol_Pod = table.Column<string>(nullable: false),
                    Shipper_Consignee = table.Column<string>(nullable: false),
                    Cargo_Charterer = table.Column<string>(nullable: false),
                    Agency = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineUps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: false),
                    DatePublication = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adress = table.Column<string>(nullable: false),
                    Postal_Code = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Usa_Phone = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    WebPage = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Port_Name = table.Column<string>(maxLength: 20, nullable: false),
                    ImageUrl = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Arrival = table.Column<DateTime>(nullable: false),
                    Anchored = table.Column<DateTime>(nullable: false),
                    Pob = table.Column<DateTime>(nullable: false),
                    AllFast = table.Column<DateTime>(nullable: false),
                    Commenced = table.Column<DateTime>(nullable: false),
                    DateUpdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Terminals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Terminal_Name = table.Column<string>(nullable: false),
                    Max_Loa = table.Column<string>(nullable: false),
                    Max_Beam = table.Column<string>(nullable: false),
                    Max_Draft = table.Column<string>(nullable: false),
                    Displacement = table.Column<string>(nullable: false),
                    Water_Density = table.Column<string>(nullable: false),
                    Working_hours = table.Column<string>(nullable: false),
                    Type_Cargo = table.Column<string>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terminals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vessels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Vessel_Name = table.Column<string>(maxLength: 30, nullable: false),
                    ImageUrl = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vessels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VesselTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type_Vessel = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VesselTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Voys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Voy_number = table.Column<int>(maxLength: 5, nullable: false),
                    Account = table.Column<string>(maxLength: 50, nullable: false),
                    Laycan = table.Column<string>(nullable: false),
                    Contract = table.Column<string>(maxLength: 50, nullable: false),
                    Cargo = table.Column<string>(maxLength: 50, nullable: false),
                    Sf = table.Column<string>(maxLength: 50, nullable: false),
                    Pol = table.Column<string>(maxLength: 50, nullable: false),
                    Facility = table.Column<string>(maxLength: 50, nullable: false),
                    Pod = table.Column<string>(maxLength: 50, nullable: false),
                    Cargo_Charterer = table.Column<string>(maxLength: 50, nullable: false),
                    Owner_Charterer = table.Column<string>(maxLength: 50, nullable: false),
                    Shipper = table.Column<string>(maxLength: 50, nullable: false),
                    Consignee = table.Column<string>(maxLength: 50, nullable: false),
                    mob = table.Column<string>(maxLength: 50, nullable: false),
                    Latitude = table.Column<string>(nullable: false),
                    Altitude = table.Column<string>(nullable: false),
                    LastKnowPosition = table.Column<DateTime>(nullable: false),
                    Eta = table.Column<DateTime>(nullable: false),
                    Etb = table.Column<DateTime>(nullable: false),
                    Etc = table.Column<DateTime>(nullable: false),
                    Etd = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voys", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alerts");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Galleries");

            migrationBuilder.DropTable(
                name: "Holds");

            migrationBuilder.DropTable(
                name: "LineUps");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Offices");

            migrationBuilder.DropTable(
                name: "Ports");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Terminals");

            migrationBuilder.DropTable(
                name: "Vessels");

            migrationBuilder.DropTable(
                name: "VesselTypes");

            migrationBuilder.DropTable(
                name: "Voys");
        }
    }
}
