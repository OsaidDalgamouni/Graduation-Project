using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DonationBank.Migrations
{
    /// <inheritdoc />
    public partial class AddForKeyToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Clothes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Clothes_ApplicationUserId",
                table: "Clothes",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clothes_AspNetUsers_ApplicationUserId",
                table: "Clothes",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clothes_AspNetUsers_ApplicationUserId",
                table: "Clothes");

            migrationBuilder.DropIndex(
                name: "IX_Clothes_ApplicationUserId",
                table: "Clothes");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Clothes");
        }
    }
}
