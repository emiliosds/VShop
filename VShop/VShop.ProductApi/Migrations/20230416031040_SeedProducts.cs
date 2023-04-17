using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VShop.ProductApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "INSERT INTO Products (Id, Name, Price, Description, Stock, ImageUrl, CategoryId) VALUES " + 
                "('aaaa',   'Caderno',    7.55,   'Caderno',            10,     'caderno.jpg',  1)," +
                "('bbbb',   'Lápis',      3.45,   'Lápis preto',        10,     'lapis.jpg',    1)," +
                "('cccc',   'Clips',      5.33,   'Clips para papel',   50,     'clips.jpg',    2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Products");
        }
    }
}
