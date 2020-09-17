using RecipeApp2.Model;
using RecipeApp2.ViewModels;
using SQLite;
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
        SQLiteConnection Connection = new SQLiteConnection(App.DatabaseLocation);
        public FavoritePageDetails(SaveRecipe SelectedSaveRecipe)
        {
            InitializeComponent();
            BindingContext = viewModel = new DetailsRecipeViewModel(SelectedSaveRecipe);
        }


        private async void RemoveFavorites_Clicked(object sender, EventArgs e)
        {
            SaveRecipe recipeModel = new SaveRecipe()
            {
                Id = viewModel.Id,
                Name = viewModel.Title,
                Ingredients = viewModel.Ingredients,
                Preparation = viewModel.Preparation,
                Favorite = false
            };
            Connection.CreateTable<SaveRecipe>();
            int rowsQuantity = Connection.Update(recipeModel);
            if (rowsQuantity > 0)
            {
                await DisplayAlert("Mensagem", "Receita Removida dos Favoritos", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Erro", "Não foi possivel desfavoritar a receita", "OK");
            }
        }
    }
}