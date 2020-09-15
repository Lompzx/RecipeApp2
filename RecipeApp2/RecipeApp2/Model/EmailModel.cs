using SQLite;

namespace RecipeApp2.Model
{
    class EmailModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(50)]
        [NotNull]
        public string Email { get; set; }
        public string PassWord { get; set; }
    }
}
