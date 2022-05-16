using ChinaSweeper.Theme;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChinaSweeper.Base
{
    public class Theme
    {
        public Color Background
        {
            get { return Colors.background; }
            set {}
        }
        
        public Color PrimaryColor
        {
            get { return Colors.primaryColor; }
            set { }
        }
        public Color SecondaryColor
        {
            get { return Colors.secondaryColor; }
            set { }
        }

        public Color PrimaryTextColor
        {
            get { return Colors.primaryTextColor; }
            set { }
        }

        public Color SecondaryTextColor
        {
            get { return Colors.secondaryTextColor; }
            set { }
        }
    }
}
