using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperMarket.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptDetails_Products_ProductId",
                table: "ReceiptDetails");

            migrationBuilder.DropIndex(
                name: "IX_ReceiptDetails_ProductId",
                table: "ReceiptDetails");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ReceiptDetails");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptDetails_IdProduct",
                table: "ReceiptDetails",
                column: "IdProduct");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptDetails_Products_IdProduct",
                table: "ReceiptDetails",
                column: "IdProduct",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptDetails_Products_IdProduct",
                table: "ReceiptDetails");

            migrationBuilder.DropIndex(
                name: "IX_ReceiptDetails_IdProduct",
                table: "ReceiptDetails");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ReceiptDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptDetails_ProductId",
                table: "ReceiptDetails",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptDetails_Products_ProductId",
                table: "ReceiptDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
