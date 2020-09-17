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
    public partial class MyRecipePageDetails : ContentPage
    {
        DetailsRecipeViewModel viewModel;
        SQLiteConnection Connection = new SQLiteConnection(App.DatabaseLocation);
        public MyRecipePageDetails(SaveRecipe SelectedSaveRecipe)
        {
            InitializeComponent();
            BindingContext = viewModel =
                new DetailsRecipeViewModel(SelectedSaveRecipe);
        }

        private async void Favorite_Clicked(object sender, EventArgs e)
        {
            if (!FavoriteIsValid(viewModel.Id))
            {
                SaveRecipe recipeModel = new SaveRecipe()
                {
                    Id = viewModel.Id,
                    Name = viewModel.Title,
                    Ingredients = viewModel.Ingredients,
                    Preparation = viewModel.Preparation,
                    Favorite = true
                };                
                Connection.CreateTable<SaveRecipe>();
                int rowsQuantity = Connection.Update(recipeModel);
                if (rowsQuantity > 0)
                {
                    await DisplayAlert("Mensagem", "Receita Favoritada", "OK");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Erro", "Não foi possivel favoritar a receita", "OK");
                }

            }
            else
            {
                await DisplayAlert("Atenção", "Receita já Favoritada", "OK");
                await Navigation.PopAsync();

            }
        }

        bool FavoriteIsValid(int id)
        {            
            Connection.CreateTable<SaveRecipe>();
            List<SaveRecipe> favorite = Connection.Table<SaveRecipe>().Where(c => c.Id == viewModel.Id).ToList();
            foreach (var item in favorite)
            {
                if (item.Favorite == true)
                {
                    return true;
                }
            }
            return false;
        }

    }
}