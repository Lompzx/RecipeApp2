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
    public partial class DetailsRecipePage : ContentPage
    {
        DetailsRecipeViewModel viewModel;

        public DetailsRecipePage(RecipeModel selectedRecipe)
        {
            InitializeComponent();

            BindingContext = viewModel = 
                new DetailsRecipeViewModel(selectedRecipe);
        }
        

        private async void Create_Clicked(object sender, EventArgs e)
        {
            CreateRecipe  recipeModel = new CreateRecipe()
            {
                Name = viewModel.Title,
                Ingredients = viewModel.Ingredients,
                Preparation = viewModel.Preparation                
            };
            SQLiteConnection Connection = new SQLiteConnection(App.DatabaseLocation);
            Connection.CreateTable<CreateRecipe>();
            int rowsQuantity = Connection.Insert(recipeModel);
            if (rowsQuantity > 0)
            {
                await DisplayAlert("Sucesso!", "Receita cadastrada com sucesso", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Falha!", "Receita não cadastrada!", "OK");
            }
        }
    }
}