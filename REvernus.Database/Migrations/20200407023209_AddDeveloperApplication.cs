using Microsoft.EntityFrameworkCore.Migrations;

namespace REvernus.Migrations
{
    public partial class AddDeveloperApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeveloperApplications",
                columns: table => new
                {
                    ClientId = table.Column<string>(nullable: false),
                    SecretKey = table.Column<string>(nullable: true),
                    CallbackUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeveloperApplications", x => x.ClientId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeveloperApplications");
        }
    }
}
