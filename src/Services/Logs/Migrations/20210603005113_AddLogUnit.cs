using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CountyRP.Services.Logs.Migrations
{
    public partial class AddLogUnit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LogUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    IP = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    ActionId = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogUnits", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogUnits");
        }
    }
}
