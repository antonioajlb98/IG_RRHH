using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IGapi.Migrations
{
    /// <inheritdoc />
    public partial class ClavesForaneas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offer_Application_Candidates_CandidateId",
                table: "Offer_Application");

            migrationBuilder.DropForeignKey(
                name: "FK_Offer_Application_Offer_OfferId",
                table: "Offer_Application");

            migrationBuilder.DropColumn(
                name: "Id_Candidate",
                table: "Offer_Application");

            migrationBuilder.DropColumn(
                name: "Id_Oferta",
                table: "Offer_Application");

            migrationBuilder.AlterColumn<int>(
                name: "OfferId",
                table: "Offer_Application",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CandidateId",
                table: "Offer_Application",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Offer_Application_Candidates_CandidateId",
                table: "Offer_Application",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Offer_Application_Offer_OfferId",
                table: "Offer_Application",
                column: "OfferId",
                principalTable: "Offer",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offer_Application_Candidates_CandidateId",
                table: "Offer_Application");

            migrationBuilder.DropForeignKey(
                name: "FK_Offer_Application_Offer_OfferId",
                table: "Offer_Application");

            migrationBuilder.AlterColumn<int>(
                name: "OfferId",
                table: "Offer_Application",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CandidateId",
                table: "Offer_Application",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id_Candidate",
                table: "Offer_Application",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_Oferta",
                table: "Offer_Application",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Offer_Application_Candidates_CandidateId",
                table: "Offer_Application",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offer_Application_Offer_OfferId",
                table: "Offer_Application",
                column: "OfferId",
                principalTable: "Offer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
