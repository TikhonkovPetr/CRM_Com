using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_CRM.Migrations
{
    /// <inheritdoc />
    public partial class Transactioncost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "cost",
                table: "Transactions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cost",
                table: "Transactions");
        }
    }
}
