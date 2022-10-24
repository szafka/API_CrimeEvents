using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LawEnforcementDB.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LawEnforcementModels",
                columns: table => new
                {
                    EnforcementId = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    EnforcementRank = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LawEnforcementModels", x => x.EnforcementId);
                });

            migrationBuilder.CreateTable(
                name: "CrimeEventModel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LawEnforcementModelEnforcementId = table.Column<string>(type: "nvarchar(8)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrimeEventModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CrimeEventModel_LawEnforcementModels_LawEnforcementModelEnforcementId",
                        column: x => x.LawEnforcementModelEnforcementId,
                        principalTable: "LawEnforcementModels",
                        principalColumn: "EnforcementId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CrimeEventModel_LawEnforcementModelEnforcementId",
                table: "CrimeEventModel",
                column: "LawEnforcementModelEnforcementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CrimeEventModel");

            migrationBuilder.DropTable(
                name: "LawEnforcementModels");
        }
    }
}
