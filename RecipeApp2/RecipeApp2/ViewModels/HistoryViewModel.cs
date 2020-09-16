using RecipeApp2.Helper;
using RecipeApp2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;


namespace RecipeApp2.ViewModels
{
   public class HistoryViewModel : BaseViewModel
    {
        private readonly HttpClient _client = new HttpClient();     
        
        public ObservableCollection<RecipeModel> Items { get; set; }

        public RecipeModel SelectedRecipe { get; set; }
        public SaveRecipe SelectedSaveRecipe { get; set; }

        public HistoryViewModel()
        {
            LoadingRecipes();          
        }

        async void LoadingRecipes()
        {
            string rescontent = await _client.GetStringAsync(Constants.RECIPEJSON_URL);
            List<RecipeModel> recipes = JsonConvert.DeserializeObject<List<RecipeModel>>(rescontent);            
            Items = new ObservableCollection<RecipeModel>(recipes);            
            OnPropertyChanged(nameof(Items));            
        }

    }

}
