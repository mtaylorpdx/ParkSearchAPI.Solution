using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParksApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NationalParks",
                columns: table => new
                {
                    NationalParkId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NationalParkName = table.Column<string>(nullable: true),
                    NationalParkState = table.Column<string>(nullable: true),
                    NationalParkCity = table.Column<string>(nullable: true),
                    NationalParkDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NationalParks", x => x.NationalParkId);
                });

            migrationBuilder.CreateTable(
                name: "StateParks",
                columns: table => new
                {
                    StateParkId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StateParkName = table.Column<string>(nullable: false),
                    StateParkState = table.Column<string>(nullable: false),
                    StateParkCity = table.Column<string>(nullable: false),
                    StateParkDescription = table.Column<string>(nullable: true),
                    NationalParkId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateParks", x => x.StateParkId);
                    table.ForeignKey(
                        name: "FK_StateParks_NationalParks_NationalParkId",
                        column: x => x.NationalParkId,
                        principalTable: "NationalParks",
                        principalColumn: "NationalParkId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "NationalParks",
                columns: new[] { "NationalParkId", "NationalParkCity", "NationalParkDescription", "NationalParkName", "NationalParkState" },
                values: new object[,]
                {
                    { 1, "NatCity 1", "NatDesc 1", "National 1", "NatState 1" },
                    { 2, "NatCity 2", "NatDesc 2", "National 2", "NatState 2" },
                    { 3, "NatCity 3", "NatDesc 3", "National 3", "NatState 3" },
                    { 4, "NatCity 4", "NatDesc 4", "National 4", "NatState 4" },
                    { 5, "NatCity 5", "NatDesc 5", "National 5", "NatState 5" }
                });

            migrationBuilder.InsertData(
                table: "StateParks",
                columns: new[] { "StateParkId", "NationalParkId", "StateParkCity", "StateParkDescription", "StateParkName", "StateParkState" },
                values: new object[,]
                {
                    { 1, null, "StateCity 1", "State Description 1", "State 1", "StateState 1" },
                    { 2, null, "StateCity 2", "State Description 2", "State 2", "StateState 2" },
                    { 3, null, "StateCity 3", "State Description 3", "State 3", "StateState 3" },
                    { 4, null, "StateCity 4", "State Description 4", "State 4", "StateState 4" },
                    { 5, null, "StateCity 5", "State Description 5", "State 5", "StateState 5" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StateParks_NationalParkId",
                table: "StateParks",
                column: "NationalParkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StateParks");

            migrationBuilder.DropTable(
                name: "NationalParks");
        }
    }
}
