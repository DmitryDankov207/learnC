using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace LearnC
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Chapter : Xamarin.Forms.TabbedPage
    {
        public Chapter( in List<string> themes, in Model.Test test)
        {
            NavigationPage.SetHasNavigationBar(this, false);

            foreach (var theme in themes)
                if (Regex.IsMatch(theme, @"\w*тест\w*"))
                    Children.Add(new TestPage(test));
                else
                {
                    GenerateThemePage(out ContentPage themePage,
                        theme, " ", themes.IndexOf(theme) + 1);
                    Children.Add(themePage);
                }
            

            InitializeComponent();
        }

        private void GenerateThemePage(out ContentPage themePage,
            in string title, in string text, in int number)
        {
            themePage = new ContentPage();
            themePage.Content = new StackLayout()
            {
                Children =
                {
                    new Label
                    {
                        VerticalOptions = LayoutOptions.StartAndExpand,
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        FontSize = 22,
                        Text = title
                    },
                    new Label
                    {
                        VerticalOptions = LayoutOptions.StartAndExpand,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Text = text
                    }
                }
            };
        }
    }
}