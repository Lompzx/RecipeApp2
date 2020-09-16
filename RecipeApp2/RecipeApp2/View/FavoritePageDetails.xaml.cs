using RecipeApp2.Model;
using RecipeApp2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RecipeApp2.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavoritePageDetails : ContentPage
    {
        DetailsRecipeViewModel viewModel;

        public FavoritePageDetails(SaveRecipe SelectedSaveRecipe)
        {
            InitializeComponent();
            BindingContext = viewModel = new DetailsRecipeViewModel(SelectedSaveRecipe);
        }


        private async void RemoveFavorites_Clicked(object sender, EventArgs e)
        {

        }
    }
}