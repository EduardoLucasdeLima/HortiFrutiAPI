using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HortiFrutiAPI.Migrations
{
    /// <inheritdoc />
    public partial class PopulaCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Categorias(Nome, ImagemURL) Values('Acidas','acidas.jpg')");
            mb.Sql("Insert into Categorias(Nome, ImagemURL) Values('Semiacidas','semiacidas.jpg')");
            mb.Sql("Insert into Categorias(Nome, ImagemURL) Values('Doces','doces.jpg')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Categorias");
        }
    }
}
