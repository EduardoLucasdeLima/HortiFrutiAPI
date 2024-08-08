using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HortiFrutiAPI.Migrations
{

    public partial class PopulaFrutas : Migration
    {

        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Frutas(Nome,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId)" +
            "Values('Laranja','Laranja é uma fruta de categoria ácida cítrica, rica em vitamina C.',3.90,'laranja.jpg',50,now(),1)");

            mb.Sql("Insert into Frutas(Nome,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId)" +
                "Values('Uva','Uva é uma fruta de categoria semiácidas, rica em vitamina C e vitamina K',8.50,'uva.jpg',10,now(),2)");

            mb.Sql("Insert into Frutas(Nome,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId)" +
               "Values('Banana','A banana é uma fruta doce e macia, rica em potássio, fibras e vitamina C.',6.75,'banana.jpg',20,now(),3)");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Frutas");
        }
    }
}
