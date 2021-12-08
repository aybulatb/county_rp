using Microsoft.EntityFrameworkCore.Migrations;

namespace CountyRP.Services.Site.Infrastructure.Migrations
{
    public partial class ChangeGroupIdToIntStep1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(16)",
                oldMaxLength: 16,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "GroupId",
                table: "Users",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Admin = table.Column<bool>(type: "bit", nullable: false),
                    AdminPanel = table.Column<bool>(type: "bit", nullable: false),
                    ChangeGroup = table.Column<bool>(type: "bit", nullable: false),
                    ChangeLogin = table.Column<bool>(type: "bit", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    CreateUsers = table.Column<bool>(type: "bit", nullable: false),
                    DeleteUsers = table.Column<bool>(type: "bit", nullable: false),
                    EditGroups = table.Column<bool>(type: "bit", nullable: false),
                    MaxBan = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    SeeLogs = table.Column<bool>(type: "bit", nullable: false),
                    BanGroupIds = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });
        }
    }
}
