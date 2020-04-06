using IsTakip.Database;
using IsTakip.Model;
using IsTakip.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace IsTakip
{
	public partial class App : Application
	{
        public static readonly string DB_NAME = "Takip";
		public App ()
		{
			InitializeComponent();
           
            MainPage = new Baslangic();

		}

		protected override void OnStart ()
		{
            // Handle when your app starts
           
        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
