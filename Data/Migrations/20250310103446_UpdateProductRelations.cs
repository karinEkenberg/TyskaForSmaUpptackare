using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TyskaForSmaUpptackare.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_ProductParts_ProductPartId",
                table: "ProductItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_Products_ProductId",
                table: "ProductItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductParts_Products_ProductId",
                table: "ProductParts");

            migrationBuilder.DropIndex(
                name: "IX_ProductItems_ProductPartId",
                table: "ProductItems");

            migrationBuilder.DropColumn(
                name: "ProductPartId",
                table: "ProductItems");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ProductParts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProductItemId",
                table: "ProductParts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductParts_ProductItemId",
                table: "ProductParts",
                column: "ProductItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_Products_ProductId",
                table: "ProductItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductParts_ProductItems_ProductItemId",
                table: "ProductParts",
                column: "ProductItemId",
                principalTable: "ProductItems",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductParts_Products_ProductId",
                table: "ProductParts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_Products_ProductId",
                table: "ProductItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductParts_ProductItems_ProductItemId",
                table: "ProductParts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductParts_Products_ProductId",
                table: "ProductParts");

            migrationBuilder.DropIndex(
                name: "IX_ProductParts_ProductItemId",
                table: "ProductParts");

            migrationBuilder.DropColumn(
                name: "ProductItemId",
                table: "ProductParts");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ProductParts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductPartId",
                table: "ProductItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductItems_ProductPartId",
                table: "ProductItems",
                column: "ProductPartId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_ProductParts_ProductPartId",
                table: "ProductItems",
                column: "ProductPartId",
                principalTable: "ProductParts",
                principalColumn: "PartId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_Products_ProductId",
                table: "ProductItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductParts_Products_ProductId",
                table: "ProductParts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
