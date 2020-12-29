using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project0.Migrations
{
    public partial class ReworkMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Floors",
                columns: table => new
                {
                    LocationCodeName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LocationSize = table.Column<int>(type: "int", nullable: false),
                    LocationRemainingTours = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Floors", x => x.LocationCodeName);
                });

            migrationBuilder.CreateTable(
                name: "FloorTourLines",
                columns: table => new
                {
                    FloorTourLineID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocationCodeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TourID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FloorTourLines", x => x.FloorTourLineID);
                });

            migrationBuilder.CreateTable(
                name: "FloorTourUsrLines",
                columns: table => new
                {
                    FloorTourLineID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocationCodeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TourID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FloorTourUsrLineID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FloorTourUsrLines", x => x.FloorTourLineID);
                });

            migrationBuilder.CreateTable(
                name: "Paintings",
                columns: table => new
                {
                    PaintingID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaintingName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationCodeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    X = table.Column<int>(type: "int", nullable: false),
                    Y = table.Column<int>(type: "int", nullable: false),
                    Cost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paintings", x => x.PaintingID);
                });

            migrationBuilder.CreateTable(
                name: "Tours",
                columns: table => new
                {
                    TourID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RowNum = table.Column<int>(type: "int", nullable: false),
                    LocationCodeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tours", x => x.TourID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Floors");

            migrationBuilder.DropTable(
                name: "FloorTourLines");

            migrationBuilder.DropTable(
                name: "FloorTourUsrLines");

            migrationBuilder.DropTable(
                name: "Paintings");

            migrationBuilder.DropTable(
                name: "Tours");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
