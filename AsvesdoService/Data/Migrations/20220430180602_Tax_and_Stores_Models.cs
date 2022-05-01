using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Tax_and_Stores_Models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Store_StoreId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Store_StoreId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Store_StoreId",
                table: "Staff");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreTax_Store_StoresStoreId",
                table: "StoreTax");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Store",
                table: "Store");

            migrationBuilder.RenameTable(
                name: "Store",
                newName: "Stores");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stores",
                table: "Stores",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Stores_StoreId",
                table: "Orders",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Stores_StoreId",
                table: "Payments",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_Stores_StoreId",
                table: "Staff",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreTax_Stores_StoresStoreId",
                table: "StoreTax",
                column: "StoresStoreId",
                principalTable: "Stores",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Stores_StoreId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Stores_StoreId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Stores_StoreId",
                table: "Staff");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreTax_Stores_StoresStoreId",
                table: "StoreTax");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stores",
                table: "Stores");

            migrationBuilder.RenameTable(
                name: "Stores",
                newName: "Store");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Store",
                table: "Store",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Store_StoreId",
                table: "Orders",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Store_StoreId",
                table: "Payments",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_Store_StoreId",
                table: "Staff",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreTax_Store_StoresStoreId",
                table: "StoreTax",
                column: "StoresStoreId",
                principalTable: "Store",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
