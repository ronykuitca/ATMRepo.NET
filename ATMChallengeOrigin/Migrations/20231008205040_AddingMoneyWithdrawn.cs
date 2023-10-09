using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ATMChallengeOrigin.Migrations
{
    /// <inheritdoc />
    public partial class AddingMoneyWithdrawn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "MoneyWithdrawn",
                table: "Operations",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MoneyWithdrawn",
                table: "Operations");
        }
    }
}
