using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChinaSweeper.InstructionsPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InstructionsPageView : ContentPage
    {
        public InstructionsPageView()
        {
            InitializeComponent();
            BindingContext = new InstructionsPageViewModel();
        }
    }
}