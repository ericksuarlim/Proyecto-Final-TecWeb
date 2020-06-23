using Microsoft.EntityFrameworkCore.Migrations;

namespace DealerAPI.Migrations
{
    public partial class AddedDealerWebsite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DealerWebsite",
                table: "Dealers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DealerWebsite",
                table: "Dealers");
        }
    }
}
