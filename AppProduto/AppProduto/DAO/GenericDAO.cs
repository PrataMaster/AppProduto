using System;
using AppProduto.Services;
using Xamarin.Forms;

namespace AppProduto
{
	public abstract class GenericDAO<T>:IDisposable
	{
		public SQLite.Net.SQLiteConnection _conexao { get; set; }
		public void init()
		{
			var config = DependencyService.Get<IConfig>();
			_conexao = new SQLite.Net.SQLiteConnection(config.Plataforma,
													   System.IO.Path.Combine(config.Diretorio, "banco1.db3"));
			_conexao.CreateTable<T>();
		}

		public void Insert(T objeto)
		{
			_conexao.Insert(objeto);
		}

		public void Update(T objeto)
		{
			_conexao.Update(objeto);
		}

		public void Delete(T objeto)
		{
			_conexao.Delete(objeto);
		}
		public void Dispose()
		{
			_conexao.Dispose();
		}
	}
}
