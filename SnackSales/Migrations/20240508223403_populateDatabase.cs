using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SnackSales.Migrations
{
    /// <inheritdoc />
    public partial class populateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categories(Name, Description) " +
                                 "VALUES('Normal','Lanche feito com ingredientes normais')");

            migrationBuilder.Sql("INSERT INTO Categories(Name,Description) " +
                                 "VALUES('Natural','Lanche feito com ingredientes integrais e naturais')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categories");
        }
    }
}
