using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project0.Migrations
{
    public partial class SecondMigrationPaintingAddition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Paintings",
                columns: table => new
                {
                    PaintingID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaintingName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FloorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    X = table.Column<int>(type: "int", nullable: false),
                    Y = table.Column<int>(type: "int", nullable: false),
                    Cost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paintings", x => x.PaintingID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Paintings");
        }
    }
}
