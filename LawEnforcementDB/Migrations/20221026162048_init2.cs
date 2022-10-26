using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LawEnforcementDB.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CrimeEvents_LawEnforcementModels_LawEnforcementModelLawEnforcementID",
                table: "CrimeEvents");

            migrationBuilder.DropColumn(
                name: "LawEnforcementId",
                table: "CrimeEvents");

            migrationBuilder.AlterColumn<string>(
                name: "LawEnforcementModelLawEnforcementID",
                table: "CrimeEvents",
                type: "nvarchar(8)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CrimeEvents_LawEnforcementModels_LawEnforcementModelLawEnforcementID",
                table: "CrimeEvents",
                column: "LawEnforcementModelLawEnforcementID",
                principalTable: "LawEnforcementModels",
                principalColumn: "LawEnforcementID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CrimeEvents_LawEnforcementModels_LawEnforcementModelLawEnforcementID",
                table: "CrimeEvents");

            migrationBuilder.AlterColumn<string>(
                name: "LawEnforcementModelLawEnforcementID",
                table: "CrimeEvents",
                type: "nvarchar(8)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)");

            migrationBuilder.AddColumn<string>(
                name: "LawEnforcementId",
                table: "CrimeEvents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_CrimeEvents_LawEnforcementModels_LawEnforcementModelLawEnforcementID",
                table: "CrimeEvents",
                column: "LawEnforcementModelLawEnforcementID",
                principalTable: "LawEnforcementModels",
                principalColumn: "LawEnforcementID");
        }
    }
}
