using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CountyRP.WebAPI.Migrations.Property
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ATMs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dimension = table.Column<long>(nullable: false),
                    BusinessId = table.Column<int>(nullable: false),
                    Position = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATMs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Businesses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    EntranceDimension = table.Column<long>(nullable: false),
                    ExitDimension = table.Column<long>(nullable: false),
                    OwnerId = table.Column<int>(nullable: false),
                    Lock = table.Column<bool>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    EntrancePosition = table.Column<string>(nullable: true),
                    ExitPosition = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Businesses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Garages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(nullable: false),
                    EntranceDimension = table.Column<long>(nullable: false),
                    EntranceRotation = table.Column<float>(nullable: false),
                    ExitDimension = table.Column<long>(nullable: false),
                    Lock = table.Column<bool>(nullable: false),
                    EntrancePosition = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntranceDimension = table.Column<long>(nullable: false),
                    ExitDimension = table.Column<long>(nullable: false),
                    OwnerId = table.Column<int>(nullable: false),
                    GarageId = table.Column<int>(nullable: false),
                    Lock = table.Column<bool>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    SafeDimension = table.Column<long>(nullable: false),
                    SafeInventoryId = table.Column<int>(nullable: false),
                    EntrancePosition = table.Column<string>(nullable: true),
                    ExitPosition = table.Column<string>(nullable: true),
                    SafePosition = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    EntranceDimension = table.Column<long>(nullable: false),
                    ExitDimension = table.Column<long>(nullable: false),
                    TypeMarker = table.Column<int>(nullable: false),
                    TypeBlip = table.Column<int>(nullable: false),
                    ColorBlip = table.Column<byte>(nullable: false),
                    GroupId = table.Column<int>(nullable: false),
                    Lock = table.Column<bool>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    LastPayment = table.Column<DateTime>(nullable: false),
                    SafeDimension = table.Column<long>(nullable: false),
                    EntrancePosition = table.Column<string>(nullable: true),
                    ExitPosition = table.Column<string>(nullable: true),
                    ColorMarker = table.Column<string>(nullable: true),
                    SafePosition = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teleports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    EntranceDimension = table.Column<long>(nullable: false),
                    ExitDimension = table.Column<long>(nullable: false),
                    TypeMarker = table.Column<int>(nullable: false),
                    TypeBlip = table.Column<int>(nullable: false),
                    ColorBlip = table.Column<byte>(nullable: false),
                    FactionId = table.Column<string>(nullable: true),
                    GangId = table.Column<int>(nullable: false),
                    RoomId = table.Column<int>(nullable: false),
                    BusinessId = table.Column<int>(nullable: false),
                    Lock = table.Column<bool>(nullable: false),
                    EntrancePosition = table.Column<string>(nullable: true),
                    ExitPosition = table.Column<string>(nullable: true),
                    ColorMarker = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teleports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<int>(nullable: false),
                    Rotation = table.Column<float>(nullable: false),
                    Dimension = table.Column<long>(nullable: false),
                    Color1 = table.Column<int>(nullable: false),
                    Color2 = table.Column<int>(nullable: false),
                    Fuel = table.Column<double>(nullable: false),
                    OwnerId = table.Column<int>(nullable: false),
                    FactionId = table.Column<string>(nullable: true),
                    Lock = table.Column<bool>(nullable: false),
                    LicensePlate = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ATMs");

            migrationBuilder.DropTable(
                name: "Businesses");

            migrationBuilder.DropTable(
                name: "Garages");

            migrationBuilder.DropTable(
                name: "Houses");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Teleports");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
