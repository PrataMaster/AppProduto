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

        ObservableCollection<Model.Produto> listaProdutos;

        public ICommand Salvar { get; set; }
        public ICommand Listar { get; set; }
        public ICommand AbrirFabricante { get; set; }
        public int codigo;
        public int Codigo { get { return codigo; } set { codigo = value; Notify("Codigo"); } }
        public string nome;
        public string Nome { get { return nome; } set { nome = value; Notify(" Nome"); } }
		public Model.Fabricante fabricante;
		public Model.Fabricante Fabricante { get {return fabricante; } set {fabricante = value;Notify("Fabricante"); } }

        public ProdutoVM()
        {
            listaProdutos = new ObservableCollection<Model.Produto>();
            Listar = new Command(AbrirLista);
            Salvar = new Command(RealizarGravacao);
            AbrirFabricante = new Command(AbrirFabricantePage);
        }

        public async void AbrirLista()
        {
            await AppProduto.App.Current.MainPage.Navigation.PushAsync(new View.ListaDeProdutosView(listaProdutos));

        }
        public void RealizarGravacao()
        {

            //listaProdutos.Add(new Model.Produto(Nome, Codigo));
			using (var dados = new DAO.ProdutoDAO())
			{
				dados.Insert(new Model.Produto { Nome = this.Nome, Codigo = this.Codigo, Fabricante = this.Fabricante});
				listaProdutos = new ObservableCollection<Model.Produto>(dados.Lista());
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
