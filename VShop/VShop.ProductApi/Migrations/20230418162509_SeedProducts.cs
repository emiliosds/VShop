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
                "VALUES ('6d872e5a-92ff-4c24-be97-2bfc5ef2356f', 'Caderno 1', 7.55, 'Caderno 1', 10, 'caderno.jpg', (SELECT Id FROM Categories WHERE Name = 'Material Escolar'))");

            migrationBuilder.Sql(
                "INSERT INTO Products (Id, Name, Price, Description, Stock, ImageUrl, CategoryId) " +
                "VALUES ('4218f36d-5152-4e75-8037-f6a4846863c6', 'Caderno 2', 6.99, 'Caderno 2', 10, 'caderno.jpg', (SELECT Id FROM Categories WHERE Name = 'Material Escolar'))");

            migrationBuilder.Sql(
                "INSERT INTO Products (Id, Name, Price, Description, Stock, ImageUrl, CategoryId) " +
                "VALUES ('5469f1a6-5222-480f-adda-b4e1b4d83d20', 'Caderno 3', 2.30, 'Caderno 3', 10, 'caderno.jpg', (SELECT Id FROM Categories WHERE Name = 'Material Escolar'))");

            migrationBuilder.Sql(
                "INSERT INTO Products (Id, Name, Price, Description, Stock, ImageUrl, CategoryId) " +
                "VALUES ('e486a70c-913d-4e5d-a97c-be2a1d98e07c', 'Caderno 4', 8.90, 'Caderno 4', 10, 'caderno.jpg', (SELECT Id FROM Categories WHERE Name = 'Material Escolar'))");

            migrationBuilder.Sql(
                "INSERT INTO Products (Id, Name, Price, Description, Stock, ImageUrl, CategoryId) " +
                "VALUES ('b7a9fc49-f8a3-4e9e-b7eb-8171ca806f76', 'Caderno 5', 4.33, 'Caderno 5', 10, 'caderno.jpg', (SELECT Id FROM Categories WHERE Name = 'Material Escolar'))");

            migrationBuilder.Sql(
                "INSERT INTO Products (Id, Name, Price, Description, Stock, ImageUrl, CategoryId) " +
                "VALUES ('e0e817fe-208e-4a5c-9f92-285fe7e49276', 'Caneta 1', 8.55, 'Caneta 1', 10, 'caneta.jpg', (SELECT Id FROM Categories WHERE Name = 'Material Escolar'))");

            migrationBuilder.Sql(
                "INSERT INTO Products (Id, Name, Price, Description, Stock, ImageUrl, CategoryId) " +
                "VALUES ('c3305c15-4e22-48a0-b6df-26d5da75c0d4', 'Caneta 2', 9.45, 'Caneta 2', 10, 'caneta.jpg', (SELECT Id FROM Categories WHERE Name = 'Material Escolar'))");

            migrationBuilder.Sql(
                "INSERT INTO Products (Id, Name, Price, Description, Stock, ImageUrl, CategoryId) " +
                "VALUES ('f8573ab7-ea8a-40d8-bf48-739bf1cc12cf', 'Caneta 3', 3.60, 'Caneta 3', 10, 'caneta.jpg', (SELECT Id FROM Categories WHERE Name = 'Material Escolar'))");

            migrationBuilder.Sql(
                "INSERT INTO Products (Id, Name, Price, Description, Stock, ImageUrl, CategoryId) " +
                "VALUES ('dd68c779-59c5-4969-96f8-4978c354b75e', 'Mochila 1', 75.5, 'Mochila 1', 10, 'mochila.jpg', (SELECT Id FROM Categories WHERE Name = 'Acessórios'))");

            migrationBuilder.Sql(
                "INSERT INTO Products (Id, Name, Price, Description, Stock, ImageUrl, CategoryId) " +
                "VALUES ('f53ff8a9-4458-4bec-9986-8923dd969993', 'Mochila 2', 3.60, 'Mochila 2', 10, 'mochila.jpg', (SELECT Id FROM Categories WHERE Name = 'Acessórios'))");

            migrationBuilder.Sql(
                "INSERT INTO Products (Id, Name, Price, Description, Stock, ImageUrl, CategoryId) " +
                "VALUES ('da167e8a-0a75-4644-8b4f-d4b0286a179c', 'Mochila 3', 3.60, 'Mochila 3', 10, 'mochila.jpg', (SELECT Id FROM Categories WHERE Name = 'Acessórios'))");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Products");
        }
    }
}