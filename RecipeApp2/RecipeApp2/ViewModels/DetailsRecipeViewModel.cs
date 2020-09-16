using RecipeApp2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace RecipeApp2.ViewModels
{
    public class DetailsRecipeViewModel : BaseViewModel
    {
        public DetailsRecipeViewModel() { }
        public DetailsRecipeViewModel(RecipeModel recipeModel)
        {
            Title = recipeModel.nome;
            Ingredients = "";
            Preparation = "";

            if (recipeModel.secao != null)
            {
                var ingredients = recipeModel.secao.FirstOrDefault(s => s.nome.ToLower() == "ingredientes");
                var preparation = recipeModel.secao.FirstOrDefault(s => s.nome.ToLower() == "modo de preparo");

                if (ingredients != null)
                {
                    Ingredients = string.Join("\n", ingredients.conteudo.Where(c => !string.IsNullOrWhiteSpace(c)));
                }
                if (preparation != null)
                {
                    Preparation = string.Join("\n", preparation.conteudo.Where(c => !string.IsNullOrWhiteSpace(c)));
                }
            }           

                OnPropertyChanged(nameof(Ingredients));
                OnPropertyChanged(nameof(Preparation));
        }

        public DetailsRecipeViewModel(SaveRecipe recipeModel)
        {
            Id = recipeModel.Id; 
            Title = recipeModel.Name;
            Ingredients = "";
            Preparation = "";

            if (recipeModel.Name != null)
            {
                var ingredients = recipeModel.Ingredients;
                var preparation = recipeModel.Preparation;

                if (ingredients != null)
                {
                    Ingredients = string.Join("\n", ingredients);
                }
                if (preparation != null)
                {
                    Preparation = string.Join("\n", preparation);
                }
            }
            OnPropertyChanged(nameof(Ingredients));
            OnPropertyChanged(nameof(Preparation));
        }


        public string Ingredients { get; set; }
        public string Preparation { get; set; }
        public int Id { get; set; }
    }
}
