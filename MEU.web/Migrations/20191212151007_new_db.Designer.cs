﻿// <auto-generated />
using System;
using MEU.web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MEU.web.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20191212151007_new_db")]
    partial class new_db
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MEU.web.Data.Entities.Alert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Alert_Date");

                    b.Property<string>("Alert_Description")
                        .IsRequired();

                    b.Property<int?>("StatusId");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("Alerts");
                });

            modelBuilder.Entity("MEU.web.Data.Entities.AlertImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AlertId");

                    b.Property<string>("ImageUrl")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("AlertId");

                    b.ToTable("AlertImages");
                });

            modelBuilder.Entity("MEU.web.Data.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CompanyId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("UserId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("MEU.web.Data.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<bool>("Pro");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("MEU.web.Data.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cargo")
                        .IsRequired();

                    b.Property<int?>("OfficeId");

                    b.Property<string>("Skype")
                        .IsRequired();

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("OfficeId");

                    b.HasIndex("UserId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("MEU.web.Data.Entities.Hold", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Actual_Quantity");

                    b.Property<DateTime>("First_Charge");

                    b.Property<int>("Hold_Number")
                        .HasMaxLength(2);

                    b.Property<bool>("Is_Empty");

                    b.Property<bool>("Is_Full");

                    b.Property<DateTime>("Last_Charge");

                    b.Property<double>("Max_Quantity");

                    b.Property<int?>("StatusId");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("Holds");
                });

            modelBuilder.Entity("MEU.web.Data.Entities.LineUp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Agency")
                        .IsRequired();

                    b.Property<string>("Cargo")
                        .IsRequired();

                    b.Property<string>("Cargo_Charterer")
                        .IsRequired();

                    b.Property<DateTime>("Eta");

                    b.Property<DateTime>("Etb");

                    b.Property<DateTime>("Etc");

                    b.Property<DateTime>("Etd");

                    b.Property<string>("Laycan")
                        .IsRequired();

                    b.Property<string>("Pol_Pod")
                        .IsRequired();

                    b.Property<string>("Quantity")
                        .IsRequired();

                    b.Property<string>("Shipper_Consignee")
                        .IsRequired();

                    b.Property<string>("Status")
                        .IsRequired();

                    b.Property<int?>("TerminalId");

                    b.Property<string>("Vessel")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("TerminalId");

                    b.ToTable("LineUps");
                });

            modelBuilder.Entity("MEU.web.Data.Entities.Manager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("MEU.web.Data.Entities.New", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatePublication");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("ImageUrl")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("News");
                });

            modelBuilder.Entity("MEU.web.Data.Entities.NewImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl")
                        .IsRequired();

                    b.Property<int?>("NewId");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("NewId");

                    b.ToTable("NewImages");
                });

            modelBuilder.Entity("MEU.web.Data.Entities.Office", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Phone")
                        .IsRequired();

                    b.Property<string>("Postal_Code")
                        .IsRequired();

                    b.Property<string>("Usa_Phone");

                    b.HasKey("Id");

                    b.ToTable("Offices");
                });

            modelBuilder.Entity("MEU.web.Data.Entities.Opinion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int>("Qualification");

                    b.Property<int?>("VoyId");

                    b.HasKey("Id");

                    b.HasIndex("VoyId");

                    b.ToTable("Opinions");
                });

            modelBuilder.Entity("MEU.web.Data.Entities.Port", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl")
                        .IsRequired();

                    b.Property<string>("Port_Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Ports");
                });

            modelBuilder.Entity("MEU.web.Data.Entities.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AllFast");

                    b.Property<DateTime>("Anchored");

                    b.Property<DateTime>("Arrival");

                    b.Property<DateTime>("Commenced");

                    b.Property<DateTime>("DateUpdate");

                    b.Property<string>("Name_status")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("Pob");

                    b.Property<int?>("VoyId");

                    b.HasKey("Id");

                    b.HasIndex("VoyId");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("MEU.web.Data.Entities.Terminal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Displacement")
                        .IsRequired();

                    b.Property<string>("ImageUrl")
                        .IsRequired();

                    b.Property<string>("Max_Beam")
                        .IsRequired();

                    b.Property<string>("Max_Draft")
                        .IsRequired();

                    b.Property<string>("Max_Loa")
                        .IsRequired();

                    b.Property<int?>("PortId");

                    b.Property<string>("Terminal_Name")
                        .IsRequired();

                    b.Property<string>("Type_Cargo")
                        .IsRequired();

                    b.Property<string>("Water_Density")
                        .IsRequired();

                    b.Property<string>("Working_hours")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("PortId");

                    b.ToTable("Terminals");
                });

            modelBuilder.Entity("MEU.web.Data.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("MEU.web.Data.Entities.Vessel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl")
                        .IsRequired();

                    b.Property<int?>("VesselTypeId");

                    b.Property<string>("Vessel_Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("VesselTypeId");

                    b.ToTable("Vessels");
                });

            modelBuilder.Entity("MEU.web.Data.Entities.VesselType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type_Vessel")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("VesselTypes");
                });

            modelBuilder.Entity("MEU.web.Data.Entities.Voy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Account")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Altitude")
                        .IsRequired();

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Cargo_Charterer")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("CompanyId");

                    b.Property<string>("Consignee")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Contract")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("EmployeeId");

                    b.Property<DateTime>("Eta");

                    b.Property<DateTime>("Etb");

                    b.Property<DateTime>("Etc");

                    b.Property<DateTime>("Etd");

                    b.Property<string>("Facility")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("LastKnowPosition");

                    b.Property<string>("Latitude")
                        .IsRequired();

                    b.Property<string>("Laycan")
                        .IsRequired();

                    b.Property<string>("Owner_Charterer")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Pod")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Pol")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("PortId");

                    b.Property<string>("Sf")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Shipper")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("VesselId");

                    b.Property<int>("Voy_number");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("PortId");

                    b.HasIndex("VesselId");

                    b.ToTable("Voys");
                });

            modelBuilder.Entity("MEU.web.Data.Entities.Voyimage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<int?>("VoyId");

                    b.HasKey("Id");

                    b.HasIndex("VoyId");

                    b.ToTable("Voyimages");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("MEU.web.Data.Entities.Alert", b =>
                {
                    b.HasOne("MEU.web.Data.Entities.Status", "Status")
                        .WithMany("Alerts")
                        .HasForeignKey("StatusId");
                });

            modelBuilder.Entity("MEU.web.Data.Entities.AlertImage", b =>
                {
                    b.HasOne("MEU.web.Data.Entities.Alert", "Alert")
                        .WithMany("AlertImages")
                        .HasForeignKey("AlertId");
                });

            modelBuilder.Entity("MEU.web.Data.Entities.Client", b =>
                {
                    b.HasOne("MEU.web.Data.Entities.Company", "Company")
                        .WithMany("Clients")
                        .HasForeignKey("CompanyId");

                    b.HasOne("MEU.web.Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MEU.web.Data.Entities.Employee", b =>
                {
                    b.HasOne("MEU.web.Data.Entities.Office", "Office")
                        .WithMany("Employees")
                        .HasForeignKey("OfficeId");

                    b.HasOne("MEU.web.Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MEU.web.Data.Entities.Hold", b =>
                {
                    b.HasOne("MEU.web.Data.Entities.Status", "Status")
                        .WithMany("Holds")
                        .HasForeignKey("StatusId");
                });

            modelBuilder.Entity("MEU.web.Data.Entities.LineUp", b =>
                {
                    b.HasOne("MEU.web.Data.Entities.Terminal", "Terminal")
                        .WithMany("LineUps")
                        .HasForeignKey("TerminalId");
                });

            modelBuilder.Entity("MEU.web.Data.Entities.Manager", b =>
                {
                    b.HasOne("MEU.web.Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MEU.web.Data.Entities.NewImage", b =>
                {
                    b.HasOne("MEU.web.Data.Entities.New", "New")
                        .WithMany("NewImages")
                        .HasForeignKey("NewId");
                });

            modelBuilder.Entity("MEU.web.Data.Entities.Opinion", b =>
                {
                    b.HasOne("MEU.web.Data.Entities.Voy", "Voy")
                        .WithMany("Opinions")
                        .HasForeignKey("VoyId");
                });

            modelBuilder.Entity("MEU.web.Data.Entities.Status", b =>
                {
                    b.HasOne("MEU.web.Data.Entities.Voy", "Voy")
                        .WithMany("Statuses")
                        .HasForeignKey("VoyId");
                });

            modelBuilder.Entity("MEU.web.Data.Entities.Terminal", b =>
                {
                    b.HasOne("MEU.web.Data.Entities.Port", "Port")
                        .WithMany("Terminals")
                        .HasForeignKey("PortId");
                });

            modelBuilder.Entity("MEU.web.Data.Entities.Vessel", b =>
                {
                    b.HasOne("MEU.web.Data.Entities.VesselType", "VesselType")
                        .WithMany("Vessels")
                        .HasForeignKey("VesselTypeId");
                });

            modelBuilder.Entity("MEU.web.Data.Entities.Voy", b =>
                {
                    b.HasOne("MEU.web.Data.Entities.Company", "Company")
                        .WithMany("Voys")
                        .HasForeignKey("CompanyId");

                    b.HasOne("MEU.web.Data.Entities.Employee", "Employee")
                        .WithMany("Voys")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("MEU.web.Data.Entities.Port", "Port")
                        .WithMany("Voys")
                        .HasForeignKey("PortId");

                    b.HasOne("MEU.web.Data.Entities.Vessel", "Vessel")
                        .WithMany("Voys")
                        .HasForeignKey("VesselId");
                });

            modelBuilder.Entity("MEU.web.Data.Entities.Voyimage", b =>
                {
                    b.HasOne("MEU.web.Data.Entities.Voy", "Voy")
                        .WithMany("Voyimages")
                        .HasForeignKey("VoyId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MEU.web.Data.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MEU.web.Data.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MEU.web.Data.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MEU.web.Data.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
