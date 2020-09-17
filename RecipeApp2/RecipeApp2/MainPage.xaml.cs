using RecipeApp2.Model;
using RecipeApp2.View;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RecipeApp2
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
        }

        void LoginButton_Clicked(Object sender, EventArgs e)
        {

            bool IsEmailEmpty = string.IsNullOrWhiteSpace(EmailEntry.Text);
            bool IsPasswordEmpty = string.IsNullOrWhiteSpace(PasswordEntry.Text);

            if (IsEmailEmpty || IsPasswordEmpty)
            {

                DisplayAlert("Mensagem", "Email e Senha obrigatórios.", "Ok");

            }
            else if (!EmailIsValid(EmailEntry.Text, PasswordEntry.Text))
            {
                DisplayAlert("Atenção", "Email ou Senha inválidos!", "Ok");
            }
            else
            {
                Navigation.PushAsync(new HomePage());
            }
        }

        bool EmailIsValid(string email, string password)
        {
            SQLiteConnection Connection = new SQLiteConnection(App.DatabaseLocation);
            try
            {                
                Connection.CreateTable<EmailModel>();
                var listEmail = Connection.Table<EmailModel>();
                foreach (var item in listEmail)
                {
                    if (item.Email == email && item.PassWord == password)
                    {
                        Connection.Close();
                        return true;
                    }
                }                
            }
            catch (Exception e)
            {
                DisplayAlert("Erro ", e.Message, "OK");   
            }
            Connection.Close();
            return false;
        }

        void NovoButton_Clicked(Object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddEmailPage());
        }
    }
}
