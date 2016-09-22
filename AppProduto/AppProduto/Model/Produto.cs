using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace AppProduto.Model
{
    [Table("Produto")]
    public class Produto
    {
        [PrimaryKey, AutoIncrement, Column("Id")]
		public int Codigo { get; set; }
		[MaxLength(70)]
        public string Nome { get; set; }
        public double Preco { get; set; }
		[ForeignKey(typeof(Fabricante))]
		public int CodigoFabricante { get;set;}
		[OneToOne]
        public Fabricante Fabricante { get; set; }

    }
}
