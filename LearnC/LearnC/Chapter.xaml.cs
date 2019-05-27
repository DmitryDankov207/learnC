using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LearnC
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Chapter : ContentPage
    {
        public List<string> Items { get; set; }

        Model.Test Test { get; }


        public Chapter(in List<string> items,
            in Model.Test test)
        {
            InitializeComponent();

            Test = test;
            Items = items;

            MyListView.ItemsSource = Items;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            
            if (e.Item == Items.Last())
                await Navigation.PushModalAsync(new TestPage(Test), false);
            
            //await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
