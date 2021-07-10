using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CountyRP.Services.Game.Infrastructure.Migrations
{
    public partial class AddPlayerEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminLevels",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Ban = table.Column<bool>(type: "bit", nullable: false),
                    CreateVehicle = table.Column<bool>(type: "bit", nullable: false),
                    EditVehicle = table.Column<bool>(type: "bit", nullable: false),
                    DeleteVehicle = table.Column<bool>(type: "bit", nullable: false),
                    CreateFaction = table.Column<bool>(type: "bit", nullable: false),
                    EditFaction = table.Column<bool>(type: "bit", nullable: false),
                    DeleteFaction = table.Column<bool>(type: "bit", nullable: false),
                    CreateHouse = table.Column<bool>(type: "bit", nullable: false),
                    EditHouse = table.Column<bool>(type: "bit", nullable: false),
                    DeleteHouse = table.Column<bool>(type: "bit", nullable: false),
                    CreateBusiness = table.Column<bool>(type: "bit", nullable: false),
                    EditBusiness = table.Column<bool>(type: "bit", nullable: false),
                    DeleteBusiness = table.Column<bool>(type: "bit", nullable: false),
                    CreateTeleport = table.Column<bool>(type: "bit", nullable: false),
                    EditTeleport = table.Column<bool>(type: "bit", nullable: false),
                    DeleteTeleport = table.Column<bool>(type: "bit", nullable: false),
                    CreateGang = table.Column<bool>(type: "bit", nullable: false),
                    EditGang = table.Column<bool>(type: "bit", nullable: false),
                    DeleteGang = table.Column<bool>(type: "bit", nullable: false),
                    CreateLockerRoom = table.Column<bool>(type: "bit", nullable: false),
                    EditLockerRoom = table.Column<bool>(type: "bit", nullable: false),
                    DeleteLockerRoom = table.Column<bool>(type: "bit", nullable: false),
                    CreateATM = table.Column<bool>(type: "bit", nullable: false),
                    EditATM = table.Column<bool>(type: "bit", nullable: false),
                    DeleteATM = table.Column<bool>(type: "bit", nullable: false),
                    CreateRoom = table.Column<bool>(type: "bit", nullable: false),
                    EditRoom = table.Column<bool>(type: "bit", nullable: false),
                    DeleteRoom = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Appearances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    MotherBlend = table.Column<int>(type: "int", nullable: false),
                    FatherBlend = table.Column<int>(type: "int", nullable: false),
                    BlendShape = table.Column<float>(type: "real", nullable: false),
                    BlendSkin = table.Column<float>(type: "real", nullable: false),
                    EyeColor = table.Column<int>(type: "int", nullable: false),
                    HairColor = table.Column<int>(type: "int", nullable: false),
                    HairHighlight = table.Column<int>(type: "int", nullable: false),
                    NoseWidth = table.Column<float>(type: "real", nullable: false),
                    NoseHeight = table.Column<float>(type: "real", nullable: false),
                    NoseBridge = table.Column<float>(type: "real", nullable: false),
                    NoseTip = table.Column<float>(type: "real", nullable: false),
                    NoseBridgeShift = table.Column<float>(type: "real", nullable: false),
                    BrowHeight = table.Column<float>(type: "real", nullable: false),
                    BrowWidth = table.Column<float>(type: "real", nullable: false),
                    CBoneHeight = table.Column<float>(type: "real", nullable: false),
                    CBoneWidth = table.Column<float>(type: "real", nullable: false),
                    CheekWidth = table.Column<float>(type: "real", nullable: false),
                    Eyes = table.Column<float>(type: "real", nullable: false),
                    Lips = table.Column<float>(type: "real", nullable: false),
                    JawWidth = table.Column<float>(type: "real", nullable: false),
                    JawHeight = table.Column<float>(type: "real", nullable: false),
                    ChinLength = table.Column<float>(type: "real", nullable: false),
                    ChinPos = table.Column<float>(type: "real", nullable: false),
                    ChinWidth = table.Column<float>(type: "real", nullable: false),
                    ChinShape = table.Column<float>(type: "real", nullable: false),
                    NeckWidth = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appearances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ATMs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dimension = table.Column<long>(type: "bigint", nullable: false),
                    BusinessId = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATMs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Businesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    EntranceDimension = table.Column<long>(type: "bigint", nullable: false),
                    ExitDimension = table.Column<long>(type: "bigint", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    LockDoors = table.Column<bool>(type: "bit", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    EntrancePosition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExitPosition = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Businesses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Factions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Color = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Ranks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gangs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Color = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Ranks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gangs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Garages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    EntranceDimension = table.Column<long>(type: "bigint", nullable: false),
                    EntranceRotation = table.Column<float>(type: "real", nullable: false),
                    ExitDimension = table.Column<long>(type: "bigint", nullable: false),
                    LockDoors = table.Column<bool>(type: "bit", nullable: false),
                    EntrancePosition = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntranceDimension = table.Column<long>(type: "bigint", nullable: false),
                    ExitDimension = table.Column<long>(type: "bigint", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    GarageId = table.Column<int>(type: "int", nullable: false),
                    LockDoors = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    SafeDimension = table.Column<long>(type: "bigint", nullable: false),
                    SafeInventoryId = table.Column<int>(type: "int", nullable: false),
                    EntrancePosition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExitPosition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SafePosition = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LockerRooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dimension = table.Column<long>(type: "bigint", nullable: false),
                    TypeMarker = table.Column<int>(type: "int", nullable: false),
                    FactionId = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColorMarker = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LockerRooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    RegistrationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastVisitDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    AdminLevelId = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    FactionId = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    GangId = table.Column<int>(type: "int", nullable: false),
                    Leader = table.Column<bool>(type: "bit", nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false),
                    CommonInventoryId = table.Column<int>(type: "int", nullable: false),
                    PocketsInventoryId = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    RegistrationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastVisitDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    EntranceDimension = table.Column<long>(type: "bigint", nullable: false),
                    ExitDimension = table.Column<long>(type: "bigint", nullable: false),
                    TypeMarker = table.Column<int>(type: "int", nullable: false),
                    TypeBlip = table.Column<int>(type: "int", nullable: false),
                    ColorBlip = table.Column<byte>(type: "tinyint", nullable: false),
                    GangId = table.Column<int>(type: "int", nullable: false),
                    LockDoors = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    LastPaymentDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    SafeDimension = table.Column<long>(type: "bigint", nullable: false),
                    EntrancePosition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExitPosition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColorMarker = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SafePosition = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teleports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    EntranceDimension = table.Column<long>(type: "bigint", nullable: false),
                    ExitDimension = table.Column<long>(type: "bigint", nullable: false),
                    TypeMarker = table.Column<int>(type: "int", nullable: false),
                    TypeBlip = table.Column<int>(type: "int", nullable: false),
                    ColorBlip = table.Column<byte>(type: "tinyint", nullable: false),
                    FactionId = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    GangId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    BusinessId = table.Column<int>(type: "int", nullable: false),
                    LockDoors = table.Column<bool>(type: "bit", nullable: false),
                    EntrancePosition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExitPosition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColorMarker = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teleports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<int>(type: "int", nullable: false),
                    Rotation = table.Column<float>(type: "real", nullable: false),
                    Dimension = table.Column<long>(type: "bigint", nullable: false),
                    Color1 = table.Column<int>(type: "int", nullable: false),
                    Color2 = table.Column<int>(type: "int", nullable: false),
                    Fuel = table.Column<double>(type: "float", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    FactionId = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    LockDoors = table.Column<bool>(type: "bit", nullable: false),
                    LicensePlate = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminLevels");

            migrationBuilder.DropTable(
                name: "Appearances");

            migrationBuilder.DropTable(
                name: "ATMs");

            migrationBuilder.DropTable(
                name: "Businesses");

            migrationBuilder.DropTable(
                name: "Factions");

            migrationBuilder.DropTable(
                name: "Gangs");

            migrationBuilder.DropTable(
                name: "Garages");

            migrationBuilder.DropTable(
                name: "Houses");

            migrationBuilder.DropTable(
                name: "LockerRooms");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Teleports");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
