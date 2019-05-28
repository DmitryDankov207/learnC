using Plugin.Settings;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LearnC
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            if (App.Current.Properties.Keys.ToArray().Length != 6)
            {
                App.Current.Properties.Add("Глава 2", false);
                App.Current.Properties.Add("Глава 3", false);
                App.Current.Properties.Add("Глава 4", false);
                App.Current.Properties.Add("Глава 5", false);
                App.Current.Properties.Add("Глава 6", false);
                App.Current.Properties.Add("Тест", false);
            }

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
