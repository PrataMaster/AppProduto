using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AppProduto.View
{
    public partial class FabricanteView : ContentPage
    {
        public FabricanteView()
        {
            InitializeComponent();
            BindingContext = new ViewModel.FabricanteVM();

			ListaFabricante.ItemTapped += async (sender, e) =>
		  {
				var fabricante = e.Item as Model.Fabricante;
				//await MVVM.App.Current.MainPage.Navigation.PushAsync(new View.Autor(livro.Id));
				await Application.Current.MainPage.Navigation.PushAsync(new View.ProdutoView(fabricante));
		  };

		}
    }
}
