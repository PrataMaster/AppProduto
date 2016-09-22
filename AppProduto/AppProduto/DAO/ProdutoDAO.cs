using System;
using System.Collections.Generic;
using System.Linq;

namespace AppProduto.DAO
{
	public class ProdutoDAO:GenericDAO<Model.Produto>
	{
		public ProdutoDAO()
		{
			init();
		}

		public List<Model.Produto> Lista()
		{
			return _conexao.Table<Model.Produto>().OrderBy(fab => fab.Nome).ToList();
		}

		public List<Model.FabricanteProduto> BuscarPorNome(string nome)
		{
			var query = _conexao.Query<Model.FabricanteProduto>("SELECT Produto.Nome NomeProduto, Fabricante.Nome NomeFabricante FROM produto,fabricante where Fabricante.Codigo = Produto.CodigoFabricante");
			return query;
		}	}
}
