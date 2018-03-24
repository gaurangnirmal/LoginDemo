using LoginDemo.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LoginDemo
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            var model = JsonConvert.DeserializeObject<Model.UserDetailsModel>(SharedPref.LoadApplicationProperty<string>(Constants.UserDataKey));
            txtEmail.Text = model.CurrentUser.Email;
            txtMobNo.Text = model.CurrentUser.Mobileno;
            txtName.Text = model.CurrentUser.Name;

        }

        private async void LogoutBtnClickedAsync(object sender, EventArgs e)
        {
            var b = await DisplayAlert("Alert", "Are you sure want to logout ?", "yes", "no");
            if (b)
            {
                SharedPref.SaveApplicationProperty(Constants.IsLoginKey,false);
                Application.Current.MainPage = new NavigationPage(new LoginPage());
            }
        }
    }
}
