using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LearnC
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThemePage : ContentPage
    {
        public ThemePage(string title, string text)
        {
            Title = title;
            TitleLabel.Text = title;
            TextLabel.Text = text;
            InitializeComponent();
        }
    }
}