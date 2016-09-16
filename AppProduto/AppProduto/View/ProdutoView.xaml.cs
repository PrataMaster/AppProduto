using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AppProduto.View
{
    public partial class ProdutoView : ContentPage
    {
        public ProdutoView()
        {
            InitializeComponent();
            this.BindingContext = new ViewModel.ProdutoVM();
            
        }
    }
}
