using Microsoft.EntityFrameworkCore.Migrations;

namespace is4aspid.Data.Migrations
{
    public partial class AddedUserIsSupervisor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSupervisor",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSupervisor",
                table: "AspNetUsers");
        }
    }
}
