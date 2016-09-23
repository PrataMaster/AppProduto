using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AppProduto.View
{
    public partial class ListaDeProdutosView : ContentPage
    {
        public ListaDeProdutosView()
        {
            InitializeComponent();
			this.BindingContext = new ViewModel.ListaDeProdutosVM();
        }
    }
}
