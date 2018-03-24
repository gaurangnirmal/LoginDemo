using LoginDemo.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace LoginDemo
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            if (SharedPref.IsContains(Constants.IsLoginKey) &&
                SharedPref.LoadApplicationProperty<bool>(Constants.IsLoginKey))
            {
                MainPage = new LoginDemo.MainPage();
            }
            else
            {
                MainPage = new NavigationPage(new LoginPage());
            }

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
