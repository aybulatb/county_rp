using Microsoft.EntityFrameworkCore.Migrations;

namespace CountyRP.Forum.Infrastructure.Migrations.Moderator
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Moderators",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityId = table.Column<int>(nullable: false),
                    EntityType = table.Column<int>(nullable: false),
                    ForumId = table.Column<int>(nullable: false),
                    CreateTopics = table.Column<bool>(nullable: false),
                    CreatePosts = table.Column<bool>(nullable: false),
                    Read = table.Column<bool>(nullable: false),
                    EditPosts = table.Column<bool>(nullable: false),
                    DeleteTopics = table.Column<bool>(nullable: false),
                    DeletePosts = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moderators", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Moderators");
        }
    }
}
