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
        SQLiteConnection Connection = new SQLiteConnection(App.DatabaseLocation);
        public DetailsRecipePage(RecipeModel selectedRecipe)
        {
            InitializeComponent();

            BindingContext = viewModel =
                new DetailsRecipeViewModel(selectedRecipe);
        }


        private async void Create_Clicked(object sender, EventArgs e)
        {
            if (!RecipeIsValid(viewModel.Title))
            {
                SaveRecipe recipeModel = new SaveRecipe()
                {
                    Name = viewModel.Title,
                    Ingredients = viewModel.Ingredients,
                    Preparation = viewModel.Preparation,
                    Favorite = false
                };

                try
                {
                    Connection.CreateTable<SaveRecipe>();
                    int rowsQuantity = Connection.Insert(recipeModel);
                    if (rowsQuantity > 0)
                    {
                        await DisplayAlert("Sucesso!", "Receita cadastrada com sucesso", "OK");
                        await Navigation.PopAsync();
                    }
                }
                catch (Exception err)
                {
                    await DisplayAlert("Falha!", "Receita não cadastrada! \n" + err.Message, "OK");

                }
            }
            else
            {
                await DisplayAlert("Atenção", "Receita já cadastrada", "OK");
                await Navigation.PopAsync();
            }
        }

        bool RecipeIsValid(string name)
        {
            try
            {
                Connection.CreateTable<SaveRecipe>();
                var recipe = Connection.Table<SaveRecipe>().Where(c => c.Name == viewModel.Title).ToList();
                foreach (var item in recipe)
                {
                    if (item.Name == viewModel.Title)
                    {
                        return true;
                    }
                }
            }
            catch (Exception err)
            {
                DisplayAlert("Erro", err.Message , "OK");
            }
            return false;
        }
    }
}