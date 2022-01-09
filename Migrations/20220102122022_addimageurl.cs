using Microsoft.EntityFrameworkCore.Migrations;

namespace _072_HammadArshad_Task1.Migrations
{
    public partial class addimageurl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "product_image",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "product_image",
                table: "Products");
        }
    }
}
