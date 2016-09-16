using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using SQLite.Net.Attributes;

namespace AppProduto.Model
{
    //[Table("Produto")]
    public class Produto
    {
        //[PrimaryKey, AutoIncrement,Column("Id")]
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public Fabricante Fabricante { get; set; }

        public Produto(string nome,int cod)
        {
            Nome = nome;
            Codigo = cod;

        }
    }
}
