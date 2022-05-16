using ChinaSweeper.Base;
using ChinaSweeper.MineSweeperPage;
using ChinaSweeper.Model;
using ChinaSweeper.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChinaSweeper.InstructionsPage
{
    public class InstructionsPageViewModel : BaseViewModel
    {
        public ICommand OnEasyClicked { get; set; }
        public ICommand OnMediumClicked { get; set; }
        public ICommand OnHardClicked { get; set; }
        
        public InstructionsPageViewModel()
        {
            Title = Titles.InstructionsPageViewTitle;
            OnEasyClicked = new Command(OnEasyClickedAsync);
        }

        private async void OnEasyClickedAsync(object obj)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new MineSweeperPageView());
        }
    }
}
