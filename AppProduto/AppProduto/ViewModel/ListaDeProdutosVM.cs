using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppProduto.ViewModel
{
    public class ListaDeProdutosVM : ViewModelBase
    {
		private ObservableCollection<Model.Produto> listaProduto;
		public ObservableCollection<Model.Produto> ListaProduto { get { return listaProduto;} set { listaProduto = value; Notify("ListaProduto");} }

		public ListaDeProdutosVM()
		{
			listaProduto = new ObservableCollection<Model.Produto>();
			using (var dados = new DAO.ProdutoDAO())
			{
				listaProduto = new ObservableCollection<Model.Produto>(dados.Lista());
			}
		}
    }
}
