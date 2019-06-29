using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab2Expense.Migrations
{
    public partial class addedPackage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryExpedition = table.Column<string>(nullable: true),
                    Sender = table.Column<string>(nullable: true),
                    CountryDestination = table.Column<string>(nullable: true),
                    Receiver = table.Column<string>(nullable: true),
                    Adress = table.Column<string>(nullable: true),
                    Cost = table.Column<double>(nullable: false),
                    Tracking = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Packages_Tracking",
                table: "Packages",
                column: "Tracking",
                unique: true,
                filter: "[Tracking] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Packages");
        }
    }
}
