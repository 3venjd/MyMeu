using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MEU.web.Migrations
{
    public partial class modifygalleries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Galleries");

            migrationBuilder.DropColumn(
                name: "mob",
                table: "Voys");

            migrationBuilder.CreateTable(
                name: "AlertImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: false),
                    AlertId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlertImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlertImages_Alerts_AlertId",
                        column: x => x.AlertId,
                        principalTable: "Alerts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NewImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: false),
                    NewId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewImages_News_NewId",
                        column: x => x.NewId,
                        principalTable: "News",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Voyimages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: false),
                    VoyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voyimages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Voyimages_Voys_VoyId",
                        column: x => x.VoyId,
                        principalTable: "Voys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlertImages_AlertId",
                table: "AlertImages",
                column: "AlertId");

            migrationBuilder.CreateIndex(
                name: "IX_NewImages_NewId",
                table: "NewImages",
                column: "NewId");

            migrationBuilder.CreateIndex(
                name: "IX_Voyimages_VoyId",
                table: "Voyimages",
                column: "VoyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlertImages");

            migrationBuilder.DropTable(
                name: "NewImages");

            migrationBuilder.DropTable(
                name: "Voyimages");

            migrationBuilder.AddColumn<string>(
                name: "mob",
                table: "Voys",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Galleries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AlertId = table.Column<int>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: false),
                    NewId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: false),
                    VoyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Galleries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Galleries_Alerts_AlertId",
                        column: x => x.AlertId,
                        principalTable: "Alerts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Galleries_News_NewId",
                        column: x => x.NewId,
                        principalTable: "News",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Galleries_Voys_VoyId",
                        column: x => x.VoyId,
                        principalTable: "Voys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
        }
    }
}
