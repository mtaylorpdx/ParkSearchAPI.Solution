using Microsoft.EntityFrameworkCore.Migrations;

namespace ParksApi.Migrations
{
    public partial class Parks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StateParks_NationalParks_NationalParkId",
                table: "StateParks");

            migrationBuilder.DropIndex(
                name: "IX_StateParks_NationalParkId",
                table: "StateParks");

            migrationBuilder.DropColumn(
                name: "NationalParkId",
                table: "StateParks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NationalParkId",
                table: "StateParks",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StateParks_NationalParkId",
                table: "StateParks",
                column: "NationalParkId");

            migrationBuilder.AddForeignKey(
                name: "FK_StateParks_NationalParks_NationalParkId",
                table: "StateParks",
                column: "NationalParkId",
                principalTable: "NationalParks",
                principalColumn: "NationalParkId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
