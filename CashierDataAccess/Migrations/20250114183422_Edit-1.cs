using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CashierDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Edit1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RemainingAmount",
                table: "Orders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "RemainingAmount",
                table: "Orders",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
