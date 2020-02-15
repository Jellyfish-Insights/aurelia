using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationModels.Migrations
{
    public partial class AddSubscribersGainedAndLost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "SubscribersGained",
                schema: "application",
                table: "SourceVideoMetrics",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SubscribersLost",
                schema: "application",
                table: "SourceVideoMetrics",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubscribersGained",
                schema: "application",
                table: "SourceVideoMetrics");

            migrationBuilder.DropColumn(
                name: "SubscribersLost",
                schema: "application",
                table: "SourceVideoMetrics");
        }
    }
}
