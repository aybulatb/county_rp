using Microsoft.EntityFrameworkCore.Migrations;

namespace CountyRP.WebAPI.Migrations.AdminLevel
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminLevels",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Ban = table.Column<bool>(nullable: false),
                    CreateVehicle = table.Column<bool>(nullable: false),
                    EditVehicle = table.Column<bool>(nullable: false),
                    DeleteVehicle = table.Column<bool>(nullable: false),
                    CreateFaction = table.Column<bool>(nullable: false),
                    EditFaction = table.Column<bool>(nullable: false),
                    DeleteFaction = table.Column<bool>(nullable: false),
                    CreateHouse = table.Column<bool>(nullable: false),
                    EditHouse = table.Column<bool>(nullable: false),
                    DeleteHouse = table.Column<bool>(nullable: false),
                    CreateBusiness = table.Column<bool>(nullable: false),
                    EditBusiness = table.Column<bool>(nullable: false),
                    DeleteBusiness = table.Column<bool>(nullable: false),
                    CreateTeleport = table.Column<bool>(nullable: false),
                    EditTeleport = table.Column<bool>(nullable: false),
                    DeleteTeleport = table.Column<bool>(nullable: false),
                    CreateGang = table.Column<bool>(nullable: false),
                    EditGang = table.Column<bool>(nullable: false),
                    DeleteGang = table.Column<bool>(nullable: false),
                    CreateLockerRoom = table.Column<bool>(nullable: false),
                    EditLockerRoom = table.Column<bool>(nullable: false),
                    DeleteLockerRoom = table.Column<bool>(nullable: false),
                    CreateATM = table.Column<bool>(nullable: false),
                    EditATM = table.Column<bool>(nullable: false),
                    DeleteATM = table.Column<bool>(nullable: false),
                    CreateRoom = table.Column<bool>(nullable: false),
                    EditRoom = table.Column<bool>(nullable: false),
                    DeleteRoom = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminLevels", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminLevels");
        }
    }
}
