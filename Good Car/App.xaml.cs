using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Good_Car.Services;
using Good_Car.Views;

namespace Good_Car
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
