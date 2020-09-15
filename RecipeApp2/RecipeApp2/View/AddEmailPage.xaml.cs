using RecipeApp2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SQLite;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RecipeApp2.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddEmailPage : ContentPage
	{
        SQLiteConnection Connection = new SQLiteConnection(App.DatabaseLocation);

        public AddEmailPage ()
		{
			InitializeComponent ();
		}

        void CreateEmailButton_Clicked(Object sender,EventArgs e)
        {
            bool IsEmailEmpty = string.IsNullOrWhiteSpace(EmailEntry.Text);

            if (IsEmailEmpty)
            {
                DisplayAlert("Atenção", "Email Obrigatório", "Ok");
            }
            else if (EmailIsValid(EmailEntry.Text))
            {
                EmailModel emailModel = new EmailModel()
                {
                    Email = EmailEntry.Text,
                    PassWord = "123"
                };

                //Create IF NOT exists
                Connection.CreateTable<EmailModel>();
                int rowsQuantity = Connection.Insert(emailModel);
                Connection.Close();
                if (rowsQuantity > 0)
                {
                    DisplayAlert("Sucesso!", "Email cadastrado com sucesso!", "OK");
                    Navigation.PushAsync(new HomePage());
                }
                else
                {
                    DisplayAlert("Falha", "Dados não inseridos no DB", "Ok");
                }
            }
        }
        
        bool EmailIsValid(string email)
        {
            string expression = "^[a-zA-Z][-_.a-zA-Z0-9]{5,29}@senac.edu.com.br$";
            if (Regex.IsMatch(email, expression))
            {
                if (Regex.Replace(email,expression,string.Empty).Length == 0)
                {
                    var listEmail = Connection.Table<EmailModel>();
                    foreach (var item in listEmail)
                    {
                        if (item.Email == email)
                        {
                            DisplayAlert("Atenção", "Email já cadastrado!!", "OK");
                            return false;
                        }
                    }
                    return true;
                }
            }
            DisplayAlert("Atenção", "Email inválido, dominio apenas (@senac.edu.br) !", "Ok");
            return false;
        }

    }
}