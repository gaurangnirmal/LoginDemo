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
	public partial class RegisterNewUserPage : ContentPage
	{
		public RegisterNewUserPage ()
		{
			InitializeComponent ();
		}

        private async void SubmitBtnClicked(object sender, EventArgs e)
        {
            if (IsValidated())
            {
                var model = new Model.UserInfo() {
                    Email=txtEmail.Text,
                    Mobileno=txtMobNo.Text,
                    Name=txtName.Text,
                    Password=txtPassword.Text
                };

                if (SharedPref.IsContains(Constants.UserDataKey))
                {
                    var userinfo = JsonConvert.DeserializeObject<Model.UserDetailsModel>(SharedPref.LoadApplicationProperty<string>(Constants.UserDataKey));
                    if (userinfo.UserList != null)
                    {
                        userinfo.UserList.Add(model);
                    }
                    else
                    {
                        userinfo.UserList = new List<Model.UserInfo>() { model };
                    }

                    SharedPref.SaveApplicationProperty(Constants.UserDataKey, JsonConvert.SerializeObject(userinfo));
                }
                else
                {
                    var userinfo = new Model.UserDetailsModel() { UserList = new List<Model.UserInfo> { model } };
                    SharedPref.SaveApplicationProperty(Constants.UserDataKey, JsonConvert.SerializeObject(userinfo));
                }

                await DisplayAlert("Alert", "User saved successfully", "Ok");
                await Navigation.PopAsync(true);
            }
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
            else if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                DisplayAlert("Alert", "Name can not be blank !", "Ok");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtMobNo.Text))
            {
                DisplayAlert("Alert", "Mobile no can not be blank !", "Ok");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                DisplayAlert("Alert", "Password can not be blank !", "Ok");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtPasswordConfirm.Text))
            {
                DisplayAlert("Alert", "Confirm Password can not be blank !", "Ok");
                return false;
            }
            else if (!txtPassword.Text.Equals(txtPasswordConfirm.Text))
            {
                DisplayAlert("Alert", "Password does not matches !", "Ok");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}