using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoApi.Migrations
{
    /// <inheritdoc />
    public partial class AddNavigationProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ListName",
                table: "TodoLists");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "TodoLists",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TodoItems_ListId",
                table: "TodoItems",
                column: "ListId");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_TodoLists_ListId",
                table: "TodoItems",
                column: "ListId",
                principalTable: "TodoLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_TodoLists_ListId",
                table: "TodoItems");

            migrationBuilder.DropIndex(
                name: "IX_TodoItems_ListId",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "TodoLists");

            migrationBuilder.AddColumn<string>(
                name: "ListName",
                table: "TodoLists",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
