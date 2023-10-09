using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ATMChallengeOrigin.Migrations
{
    /// <inheritdoc />
    public partial class AddingErrorCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ErrorCount",
                table: "Cards",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ErrorCount",
                table: "Cards");
        }
    }
}
