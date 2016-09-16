using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite.Net.Interop;
using Xamarin.Forms;

[assembly: Dependency(typeof(AppProduto.Droid.Config))]
namespace AppProduto.Droid
{
    public class Config : Services.IConfig
    {
        private string _diretorio;
        private ISQLitePlatform _plataforma;
        public string Diretorio
        {
            get
            {
                if (string.IsNullOrEmpty(_diretorio))
                {
                    _diretorio = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                    //Para IOS
                    //var pasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                    //_diretorio = System.IO.Path.Combine(pasta, "..", "Library");
                }
                //throw new NotImplementedException();
                return _diretorio;
            }
        }

        public ISQLitePlatform Plataforma
        {
            get
            {
                if (_plataforma == null)
                {
                    _plataforma = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
                    //throw new NotImplementedException();
                }
                return _plataforma;
            }
        }
    }
}