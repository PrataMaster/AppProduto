using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppProduto.ViewModel
{
    class FabricanteVM : ViewModelBase
    {
        public ICommand SalvarCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        private int codigo;
        public int Codigo { get { return codigo; } set { codigo = value; Notify("Codigo"); } }
        private string nome;
        public string Nome { get { return nome; } set { nome = value; Notify("Nome"); } }
        private Model.Fabricante fab;
        public Model.Fabricante FAB { get { return fab; } set { fab = value; Notify("FAB"); } }
        private List<Model.Fabricante> fabricante;
        public List<Model.Fabricante> Fabricante { get { return fabricante; } set { fabricante = value; Notify("Fabricante"); } }

        private Model.Fabricante itemSelected;
        public Model.Fabricante ItemSelected { get { return itemSelected; } set { itemSelected = value; Notify("ItemSelected"); } }


        public FabricanteVM()
        {
            using (var dados = new DAO.FabricanteDAO())
            {
                Fabricante = dados.Lista();
            }
            SalvarCommand = new Command(InserirFabricante);
            DeleteCommand = new Command(DeletarFabricante);
        }

        public void InserirFabricante()
        {
            using (var dados = new DAO.FabricanteDAO())
            {
                dados.Insert(new Model.Fabricante { Codigo = this.Codigo, Nome = this.Nome });
                Fabricante = dados.Lista();
            }
        }

        public void DeletarFabricante()
        {


            using (var dados = new DAO.FabricanteDAO())
            {
                dados.Delete(ItemSelected);
                Fabricante = dados.Lista();
            }
        }
    }
}
