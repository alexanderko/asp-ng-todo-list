using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoSpa.Migrations
{
    public partial class Initail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: false),
                    IsDone = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "IsDone", "Title" },
                values: new object[] { 1L, false, "Register on Meetup" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "IsDone", "Title" },
                values: new object[] { 2L, false, "Get amazed by ASP.NET Core" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "IsDone", "Title" },
                values: new object[] { 3L, false, "Apply to InterLink inCamp" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
