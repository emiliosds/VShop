using Microsoft.EntityFrameworkCore.Migrations;

namespace VShop.ProductApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "INSERT INTO Products (Id, Name, Price, Description, Stock, ImageUrl, CategoryId) " +
                "VALUES ((SELECT uuid()),   'Caderno',    7.55,   'Caderno',            10,     'caderno.jpg',  (SELECT Id FROM Categories WHERE Name = 'Material Escolar'))");

             migrationBuilder.Sql(
                "INSERT INTO Products (Id, Name, Price, Description, Stock, ImageUrl, CategoryId) " +
                "VALUES ((SELECT uuid()),   'Lápis',      3.45,   'Lápis preto',        10,     'lapis.jpg',    (SELECT Id FROM Categories WHERE Name = 'Material Escolar'))");

            migrationBuilder.Sql(
                "INSERT INTO Products (Id, Name, Price, Description, Stock, ImageUrl, CategoryId) " +
                "VALUES ((SELECT uuid()),   'Clips',      5.33,   'Clips para papel',   50,     'clips.jpg',    (SELECT Id FROM Categories WHERE Name = 'Acessórios'))");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Products");
        }
    }
}