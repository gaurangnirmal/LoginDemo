using System;
using System.Collections.Generic;
using System.Text;

namespace LoginDemo.Helper
{
    public static class SharedPref
    {
        public static async void SaveApplicationProperty<T>(string key, T value)
        {
            Xamarin.Forms.Application.Current.Properties[key] = value;
            await Xamarin.Forms.Application.Current.SavePropertiesAsync();
        }

        public static T LoadApplicationProperty<T>(string key)
        {
            return (T)Xamarin.Forms.Application.Current.Properties[key];
        }

        public static bool IsContains(string key)
        {
            return Xamarin.Forms.Application.Current.Properties.ContainsKey(key);
        }
    }
}
