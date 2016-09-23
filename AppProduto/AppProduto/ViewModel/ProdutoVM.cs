using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppProduto.ViewModel
{
    public class ProdutoVM : ViewModelBase
    {
        public ICommand Salvar { get; set; }
        public ICommand Listar { get; set; }
        public ICommand AbrirFabricante { get; set; }
        private int codigo;
        public int Codigo { get { return codigo; } set { codigo = value; Notify("Codigo"); } }
		private string nome;
        public string Nome { get { return nome; } set { nome = value; Notify("Nome"); } }
		private Model.Fabricante fabricante;
		public Model.Fabricante Fabricante { get {return fabricante; } set {fabricante = value;Notify("Fabricante"); } }
		private string nomeFab;
		public string NomeFab { get { return nomeFab;}set { nomeFab = value; Notify("NomeFab");} }

        public ProdutoVM()
        {
            Listar = new Command(AbrirLista);
            Salvar = new Command(RealizarGravacao);
            AbrirFabricante = new Command(AbrirFabricantePage);
        }

		public ProdutoVM(Model.Fabricante fab)
		{
			Fabricante = fab;
			NomeFab = fab.Nome;
			Listar = new Command(AbrirLista);
			Salvar = new Command(RealizarGravacao);
			AbrirFabricante = new Command(AbrirFabricantePage);
		}

        public async void AbrirLista()
        {
            await AppProduto.App.Current.MainPage.Navigation.PushAsync(new View.ListaDeProdutosView());

        }
        public void RealizarGravacao()
        {

            //listaProdutos.Add(new Model.Produto(Nome, Codigo));
			using (var dados = new DAO.ProdutoDAO())
			{
				dados.Insert(new Model.Produto { Nome = this.Nome, Codigo = this.Codigo, CodigoFabricante = this.Fabricante.Codigo, NomeFabricante = this.NomeFab});
			}

            //CodigoTeste = listaProdutos[0].Codigo;
            //NomeProdutoTeste = listaProdutos[0].Nome;

        }

        public async void AbrirFabricantePage()
        {
            await AppProduto.App.Current.MainPage.Navigation.PushAsync(new View.FabricanteView());
        }
    }
}
