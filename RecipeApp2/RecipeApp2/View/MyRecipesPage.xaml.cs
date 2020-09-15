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
	public partial class MyRecipesPage : ContentPage
	{
        RecipesViewModel viewModel;
		public MyRecipesPage ()
		{
			InitializeComponent ();
            BindingContext = viewModel = new RecipesViewModel();
        }

       

        protected override void OnAppearing()
        {
            base.OnAppearing();
            SQLiteConnection Connection = new SQLiteConnection(App.DatabaseLocation);
            Connection.CreateTable<CreateRecipe>();
            var RecipePost = Connection.Table<CreateRecipe>().ToList();
            RecipePostView.ItemsSource = RecipePost;
            Connection.Close();
        }

    }
}