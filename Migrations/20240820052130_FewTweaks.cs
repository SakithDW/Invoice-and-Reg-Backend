using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoginAPIDotNet7_2.Migrations
{
    /// <inheritdoc />
    public partial class FewTweaks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Products",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "OrderItems",
                newName: "OrderItemId");

            migrationBuilder.RenameColumn(
                name: "OrderID",
                table: "Headers",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Headers",
                newName: "HeaderId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Contacts",
                newName: "ContactId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Products",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "OrderItemId",
                table: "OrderItems",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Headers",
                newName: "OrderID");

            migrationBuilder.RenameColumn(
                name: "HeaderId",
                table: "Headers",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "ContactId",
                table: "Contacts",
                newName: "Id");
        }
    }
}
