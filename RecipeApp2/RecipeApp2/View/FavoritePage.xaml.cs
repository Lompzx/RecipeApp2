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
    public partial class FavoritePage : ContentPage
    {
        HistoryViewModel viewModel;
        public FavoritePage()
        {
            InitializeComponent();
            BindingContext = viewModel = new HistoryViewModel();
        }

        protected override void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                SQLiteConnection Connection = new SQLiteConnection(App.DatabaseLocation);
                Connection.CreateTable<SaveRecipe>();
                var RecipePost = Connection.Table<SaveRecipe>().Where(c => c.Favorite == true).ToList();
                RecipePostView.ItemsSource = RecipePost;
                Connection.Close();
            }
            catch (Exception e)
            {
                DisplayAlert("Erro ", e.Message, "OK");
            }
        }

        private async void ListView_ItemSelected(object sender, EventArgs e)
        {
            if (viewModel.SelectedSaveRecipe != null)
            {
                await Navigation.PushAsync(new FavoritePageDetails(viewModel.SelectedSaveRecipe));
            }
        }
    }
}