using Microsoft.EntityFrameworkCore.Migrations;

namespace MessageApp.Infrastructure.Data.Migrations
{
    public partial class isVisibleUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsVisible",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsVisible",
                table: "AspNetUsers");
        }
    }
}
