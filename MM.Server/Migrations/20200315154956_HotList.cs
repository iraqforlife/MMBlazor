using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MM.Server.Migrations
{
    public partial class HotList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HotList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Symbol = table.Column<string>(maxLength: 5, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Archvied = table.Column<bool>(nullable: false),
                    Image = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotList", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotList");
        }
    }
}
