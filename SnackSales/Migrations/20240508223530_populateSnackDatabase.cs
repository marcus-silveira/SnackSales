using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SnackSales.Migrations
{
    /// <inheritdoc />
    public partial class populateSnackDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Snacks(CategoryId,ShortDescription,LongDescription,InStock,ImageThumbnailUrl,ImageUrl,IsFavorite,Name,Price, CreatedAt) VALUES(1,'Pão, hambúrger, ovo, presunto, queijo e batata palha','Delicioso pão de hambúrger com ovo frito; presunto e queijo de primeira qualidade acompanhado com batata palha',1, 'http://www.macoratti.net/Imagens/Snacks/cheesesalada1.jpg','http://www.macoratti.net/Imagens/Snacks/cheesesalada1.jpg', 0 ,'Cheese Salada', 12.50, '08/05/2024 19:46:27')");
            migrationBuilder.Sql("INSERT INTO Snacks(CategoryId,ShortDescription,LongDescription,InStock,ImageThumbnailUrl,ImageUrl,IsFavorite,Name,Price, CreatedAt) VALUES(1,'Pão, presunto, mussarela e tomate','Delicioso pão francês quentinho na chapa com presunto e mussarela bem servidos com tomate preparado com carinho.',1,'http://www.macoratti.net/Imagens/Snacks/mistoquente4.jpg','http://www.macoratti.net/Imagens/Snacks/mistoquente4.jpg',0,'Misto Quente', 8.00, '08/05/2024 19:46:27')");
            migrationBuilder.Sql("INSERT INTO Snacks(CategoryId,ShortDescription,LongDescription,InStock,ImageThumbnailUrl,ImageUrl,IsFavorite,Name,Price, CreatedAt) VALUES(1,'Pão, hambúrger, presunto, mussarela e batalha palha','Pão de hambúrger especial com hambúrger de nossa preparação e presunto e mussarela; acompanha batata palha.',1,'http://www.macoratti.net/Imagens/Snacks/cheeseburger1.jpg','http://www.macoratti.net/Imagens/Snacks/cheeseburger1.jpg',0,'Cheese Burger', 11.00, '08/05/2024 19:46:27')");
            migrationBuilder.Sql("INSERT INTO Snacks(CategoryId,ShortDescription,LongDescription,InStock,ImageThumbnailUrl,ImageUrl,IsFavorite,Name,Price, CreatedAt) VALUES(2,'Pão Integral, queijo branco, peito de peru, cenoura, alface, iogurte','Pão integral natural com queijo branco, peito de peru e cenoura ralada com alface picado e iorgurte natural.',1,'http://www.macoratti.net/Imagens/Snacks/lanchenatural.jpg','http://www.macoratti.net/Imagens/Snacks/lanchenatural.jpg',1,'Lanche Natural Peito Peru', 15.00, '08/05/2024 19:46:27')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Snacks");
        }
    }
}
