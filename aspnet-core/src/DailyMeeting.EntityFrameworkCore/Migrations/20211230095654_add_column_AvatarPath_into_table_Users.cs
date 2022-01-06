using Microsoft.EntityFrameworkCore.Migrations;

namespace DailyMeeting.Migrations
{
    public partial class add_column_AvatarPath_into_table_Users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AvatarPath",
                table: "AbpUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvatarPath",
                table: "AbpUsers");
        }
    }
}
