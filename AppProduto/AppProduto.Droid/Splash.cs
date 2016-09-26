using System;
using Android.App;
using Android.OS;

namespace AppProduto.Droid
{
		[Activity(Theme = "@style/MainSplash",  //Indicates the theme to use for this activity
				MainLauncher = true,//set it as boot activity
				NoHistory = true)]//Doesn't place it in back stack
		public class Splash : Activity
		{
			protected override void OnCreate(Bundle savedInstanceState)
			{
				base.OnCreate(savedInstanceState);

				// Create your application here
				System.Threading.Thread.Sleep(100); //Let's wait a while...
				this.StartActivity(typeof(MainActivity));
			}
		}
	}
