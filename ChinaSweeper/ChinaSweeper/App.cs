using ChinaSweeper.InstructionsPage;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChinaSweeper
{
    public partial class App : Application
    {
        public App()
        {
            MainPage = new NavigationPage(new InstructionsPageView());
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
