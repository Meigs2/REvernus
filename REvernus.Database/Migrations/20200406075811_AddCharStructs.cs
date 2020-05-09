using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace REvernus.Database.Migrations
{
    public partial class AddCharStructs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddedStructures",
                columns: table => new
                {
                    StructureId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    OwnerId = table.Column<int>(nullable: false),
                    SolarSystemId = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false),
                    AddedBy = table.Column<long>(nullable: false),
                    AddedAt = table.Column<DateTime>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    IsPublic = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddedStructures", x => x.StructureId);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    CharacterId = table.Column<int>(nullable: false),
                    CharacterName = table.Column<string>(nullable: true),
                    RefreshToken = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.CharacterId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddedStructures");

            migrationBuilder.DropTable(
                name: "Characters");
        }
    }
}
