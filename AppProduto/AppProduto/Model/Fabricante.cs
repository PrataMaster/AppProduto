using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
namespace AppProduto.Model
{
    [Table("Fabricante")]
    public class Fabricante
    {
        [PrimaryKey, AutoIncrement]        
        public int Codigo { get; set; }
        public string Nome { get; set; }

    }
}
