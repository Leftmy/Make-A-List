using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MakeAList.Migrations
{
    /// <inheritdoc />
    public partial class AddUrlToListItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "ListItems",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "ListItems");
        }
    }
}
