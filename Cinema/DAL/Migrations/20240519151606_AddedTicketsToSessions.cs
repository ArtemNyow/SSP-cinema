using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedTicketsToSessions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Sessions_SessionID",
                table: "Tickets");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Sessions_SessionID",
                table: "Tickets",
                column: "SessionID",
                principalTable: "Sessions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Sessions_SessionID",
                table: "Tickets");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Sessions_SessionID",
                table: "Tickets",
                column: "SessionID",
                principalTable: "Sessions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
