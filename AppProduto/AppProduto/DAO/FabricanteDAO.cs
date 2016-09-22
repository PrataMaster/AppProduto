using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppProduto.DAO
{
	public class FabricanteDAO : GenericDAO<Model.Fabricante>
    {
        public FabricanteDAO()
        {
			init();
        }

        public List<Model.Fabricante> Lista()
        {
            return _conexao.Table<Model.Fabricante>().OrderBy(fab => fab.Nome).ToList();
        }

        public Model.Fabricante BuscarPorCodigo(int cod)
        {
            return _conexao.Table<Model.Fabricante>().FirstOrDefault(fab => fab.Codigo == cod);
        }

        public List<Model.Fabricante> BuscarPorNome(string nome)
        {
            var query = _conexao.Query<Model.Fabricante>("SELECT * FROM Fabricante WHERE Nome = ?", nome);
            return query;
        }

        public string BuscarPorNomeLinq(string nome)
        {
            var query = from fab in _conexao.Table<Model.Fabricante>() where fab.Nome.StartsWith(nome) select fab;
            return query.FirstOrDefault().Nome;
        }
    }
}
