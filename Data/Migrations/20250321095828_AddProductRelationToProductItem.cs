using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TyskaForSmaUpptackare.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddProductRelationToProductItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId1",
                table: "ProductItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductItems_ProductId1",
                table: "ProductItems",
                column: "ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_Products_ProductId1",
                table: "ProductItems",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_Products_ProductId1",
                table: "ProductItems");

            migrationBuilder.DropIndex(
                name: "IX_ProductItems_ProductId1",
                table: "ProductItems");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "ProductItems");
        }
    }
}
