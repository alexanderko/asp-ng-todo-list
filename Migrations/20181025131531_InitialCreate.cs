using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoSpa.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TodoLists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: false),
                    IsDone = table.Column<bool>(nullable: false),
                    TodoListId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_TodoLists_TodoListId",
                        column: x => x.TodoListId,
                        principalTable: "TodoLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TodoLists",
                columns: new[] { "Id", "Title" },
                values: new object[] { 1, "Get Junior Developer Position" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "IsDone", "Title", "TodoListId" },
                values: new object[] { 1L, true, "Register on Meetup", 1 });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "IsDone", "Title", "TodoListId" },
                values: new object[] { 2L, false, "Get amazed by ASP.NET Core", 1 });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "IsDone", "Title", "TodoListId" },
                values: new object[] { 3L, false, "Apply to InterLink inCamp", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TodoListId",
                table: "Tasks",
                column: "TodoListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "TodoLists");
        }
    }
}
