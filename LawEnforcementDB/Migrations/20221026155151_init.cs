using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LawEnforcementDB.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LawEnforcementModels",
                columns: table => new
                {
                    LawEnforcementID = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    EnforcementRank = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LawEnforcementModels", x => x.LawEnforcementID);
                });

            migrationBuilder.CreateTable(
                name: "CrimeEvents",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LawEnforcementId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LawEnforcementModelLawEnforcementID = table.Column<string>(type: "nvarchar(8)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrimeEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CrimeEvents_LawEnforcementModels_LawEnforcementModelLawEnforcementID",
                        column: x => x.LawEnforcementModelLawEnforcementID,
                        principalTable: "LawEnforcementModels",
                        principalColumn: "LawEnforcementID");
                });

            migrationBuilder.InsertData(
                table: "LawEnforcementModels",
                columns: new[] { "LawEnforcementID", "EnforcementRank" },
                values: new object[,]
                {
                    { "AAS11421", "SERGEANT" },
                    { "AGF66633", "LIEUTENANT" },
                    { "ANC66431", "CAPTAIN" },
                    { "AZZ33405", "CORPORAL" },
                    { "EES11521", "LIEUTENANT" },
                    { "GDS11643", "PATROL OFFICER" },
                    { "HJS18891", "POLICE DETECTIVE" },
                    { "LUS33721", "SERGEANT" },
                    { "XVS16321", "LIEUTENANT" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CrimeEvents_LawEnforcementModelLawEnforcementID",
                table: "CrimeEvents",
                column: "LawEnforcementModelLawEnforcementID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CrimeEvents");

            migrationBuilder.DropTable(
                name: "LawEnforcementModels");
        }
    }
}
