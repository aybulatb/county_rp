using Microsoft.EntityFrameworkCore.Migrations;

namespace CountyRP.Services.Site.Infrastructure.Migrations
{
    public partial class ChangeGroupIdToIntStep2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Color = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    Admin = table.Column<bool>(type: "bit", nullable: false),
                    AdminPanel = table.Column<bool>(type: "bit", nullable: false),
                    CreateUsers = table.Column<bool>(type: "bit", nullable: false),
                    DeleteUsers = table.Column<bool>(type: "bit", nullable: false),
                    ChangeLogin = table.Column<bool>(type: "bit", nullable: false),
                    ChangeGroup = table.Column<bool>(type: "bit", nullable: false),
                    EditGroups = table.Column<bool>(type: "bit", nullable: false),
                    MaxBan = table.Column<int>(type: "int", nullable: false),
                    SeeLogs = table.Column<bool>(type: "bit", nullable: false),
                    BanGroupIds = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
