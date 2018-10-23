using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoSpa.Migrations
{
    public partial class MarkSeedTaskDone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1L,
                column: "IsDone",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1L,
                column: "IsDone",
                value: false);
        }
    }
}
