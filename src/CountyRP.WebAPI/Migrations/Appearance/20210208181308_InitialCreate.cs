using Microsoft.EntityFrameworkCore.Migrations;

namespace CountyRP.WebAPI.Migrations.Appearance
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appearances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gender = table.Column<bool>(nullable: false),
                    MotherBlend = table.Column<int>(nullable: false),
                    FatherBlend = table.Column<int>(nullable: false),
                    BlendShape = table.Column<float>(nullable: false),
                    BlendSkin = table.Column<float>(nullable: false),
                    EyeColor = table.Column<int>(nullable: false),
                    HairColor = table.Column<int>(nullable: false),
                    HairHighlight = table.Column<int>(nullable: false),
                    NoseWidth = table.Column<float>(nullable: false),
                    NoseHeight = table.Column<float>(nullable: false),
                    NoseBridge = table.Column<float>(nullable: false),
                    NoseTip = table.Column<float>(nullable: false),
                    NoseBridgeShift = table.Column<float>(nullable: false),
                    BrowHeight = table.Column<float>(nullable: false),
                    BrowWidth = table.Column<float>(nullable: false),
                    CBoneHeight = table.Column<float>(nullable: false),
                    CBoneWidth = table.Column<float>(nullable: false),
                    CheekWidth = table.Column<float>(nullable: false),
                    Eyes = table.Column<float>(nullable: false),
                    Lips = table.Column<float>(nullable: false),
                    JawWidth = table.Column<float>(nullable: false),
                    JawHeight = table.Column<float>(nullable: false),
                    ChinLength = table.Column<float>(nullable: false),
                    ChinPos = table.Column<float>(nullable: false),
                    ChinWidth = table.Column<float>(nullable: false),
                    ChinShape = table.Column<float>(nullable: false),
                    NeckWidth = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appearances", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appearances");
        }
    }
}
