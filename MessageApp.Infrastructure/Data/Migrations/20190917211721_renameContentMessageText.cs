using Microsoft.EntityFrameworkCore.Migrations;

namespace MessageApp.Infrastructure.Data.Migrations
{
    public partial class renameContentMessageText : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Messages",
                newName: "MessageText");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MessageText",
                table: "Messages",
                newName: "Content");
        }
    }
}
