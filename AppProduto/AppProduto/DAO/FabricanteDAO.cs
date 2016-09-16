using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppProduto.DAO
{
    public class FabricanteDAO : IDisposable
    {
        private SQLite.Net.SQLiteConnection _conexao;
        public FabricanteDAO()
        {
            var config = DependencyService.Get<Services.IConfig>();
            _conexao = new SQLite.Net.SQLiteConnection(config.Plataforma, System.IO.Path.Combine(config.Diretorio, "banco1.db3"));
            _conexao.CreateTable<Model.Fabricante>();
        }

        public void Insert(Model.Fabricante fabricante)
        {
            _conexao.Insert(fabricante);
        }

        public void Update(Model.Fabricante fabricante)
        {
            _conexao.Update(fabricante);
        }

        public void Delete(Model.Fabricante fabricante)
        {
            _conexao.Delete(fabricante);
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


        public void Dispose()
        {
            _conexao.Dispose();
        }
    }
}
