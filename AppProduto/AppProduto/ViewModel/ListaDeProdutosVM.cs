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

        public ListaDeProdutosVM(ObservableCollection<Model.Produto> prod)
        {
            this.Produtos = prod;

        }

        private ObservableCollection<Model.Produto> produtos;

        public ObservableCollection<Model.Produto> Produtos
        {
            get
            {

                return produtos;
            }
            set
            {
                produtos = value;
                Notify("Produtos");
            }
        }
    }
}
    
