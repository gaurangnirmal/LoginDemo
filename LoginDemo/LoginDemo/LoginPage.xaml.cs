using LoginDemo.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginDemo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginBtnClicked(object sender, EventArgs e)
        {
            if (IsValidated())
            {
                if (IsValidUserOrNot())
                {
                    SharedPref.SaveApplicationProperty(Constants.IsLoginKey, true);
                    App.Current.MainPage = new MainPage();
                }
            }
        }

        private void RegisterNewUserBtnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterNewUserPage());
        }

        public bool IsValidated()
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                DisplayAlert("Alert", "Email can not be blank !", "Ok");
                return false;
            }
            else if (!Regex.IsMatch(txtEmail.Text, @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?"))
            {
                DisplayAlert("Alert", "Enter valid email address", "Ok");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                DisplayAlert("Alert", "Password can not be blank !", "Ok");
                return false;
            }
            
            return true;
        }

        public bool IsValidUserOrNot()
        {
            if (!SharedPref.IsContains(Constants.UserDataKey))
            {
                DisplayAlert("Alert","No such user availible","Ok");
                return false;
            }
            else
            {
                var model = JsonConvert.DeserializeObject<Model.UserDetailsModel>(SharedPref.LoadApplicationProperty<string>(Constants.UserDataKey));
                var b = model.UserList.Single(t=> t.Email.Equals(txtEmail.Text,StringComparison.InvariantCultureIgnoreCase));
                if (b == null)
                {
                    DisplayAlert("Alert", "No such user availible", "Ok");
                    return false;
                }
                else if (b.Email.Equals(txtEmail.Text, StringComparison.InvariantCultureIgnoreCase) && b.Password.Equals(txtPassword.Text))
                {
                    model.CurrentUser = b;
                    SharedPref.SaveApplicationProperty(Constants.UserDataKey,JsonConvert.SerializeObject(model));
                    return true;
                }
                else
                {
                    DisplayAlert("Alert", "Email or password is incorrect ! ", "Ok");
                    return false;
                }
            }
        }
    }
}