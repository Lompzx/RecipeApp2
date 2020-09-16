
using SQLite;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
namespace RecipeApp2.Model
{

    public class RecipeModel
    {
        public Identification _id { get; set; }
        private string _nome { get; set; }
        public string nome { get { return _nome; } set { _nome = value.Trim(); } }
        public ObservableCollection<Secao> secao { get; set; }
    }

    public class Identification
    {
        public string oid { get; set; }
    }

    public class Secao
    {
        private string _nome { get; set; }
        public string nome { get { return _nome; } set { _nome = value.Trim(); } }
        public ObservableCollection<string> conteudo { get; set; }
    }

    public class SaveRecipe
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public string Preparation { get; set; }
        public bool Favorite { get; set; }
    }

}




















/*using SQLite;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace RecipeApp2.Model
{
    [DataContract]
    public class RecipeModel
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember(Name ="nome")]
        public string RecipeName { get; set; }
        [DataMember(Name ="secao:nome")]
        public List<string> Ingredients { get; set; }
    }

   
}*/
