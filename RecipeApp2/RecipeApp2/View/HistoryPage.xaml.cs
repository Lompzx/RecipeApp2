using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RecipeApp2.Model;
using System.Collections.ObjectModel;
using RecipeApp2.Helper;
using Newtonsoft.Json;
using RecipeApp2.ViewModels;

namespace RecipeApp2.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryPage : ContentPage
    {
        HistoryViewModel viewModel;       
        public HistoryPage()
        {
            InitializeComponent();
            try
            {
                BindingContext = viewModel = new HistoryViewModel();
            }
            catch (Exception e)
            {
                DisplayAlert("Atenção","Erro: " + viewModel.MessageError +"\n" + e.Message,"OK");
            }
            
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (viewModel.SelectedRecipe != null)
            {
                await Navigation.PushAsync(new DetailsRecipePage(viewModel.SelectedRecipe));
            }
        }
    }
}