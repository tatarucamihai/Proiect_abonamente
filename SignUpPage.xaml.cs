
using System;
using Proiect_abonamente.Data;
using Proiect_abonamente.Models;


namespace Proiect_abonamente
{

    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        private async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            string firstName = firstNameEntry.Text;
            string lastName = lastNameEntry.Text;
            int age = Convert.ToInt32(ageEntry.Text);
            string email = emailEntry.Text;
            string password = passwordEntry.Text;

            // Verificați dacă utilizatorul cu acest email există deja în baza de date
            var existingUser = await App.Database.GetClientByEmailAsync(email);
            if (existingUser != null)
            {
                // Utilizatorul există deja, afișați un mesaj sau faceți altă acțiune corespunzătoare
                // de ex. "Adresa de email este deja înregistrată."
                DisplayAlert("Error", "Email address is already registered.", "OK");
                return;
            }

            // Salvați noul utilizator în baza de date
            var newUser = new Client
            {
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                Email = email,
                Password = password,
                IsLoggedIn = false // La înregistrare, utilizatorul nu este încă logat
            };
            await App.Database.SaveClientModelAsync(newUser);

            // După înregistrare, poți redirecționa utilizatorul către pagina de start sau altă pagină relevantă
            await Navigation.PushAsync(new HomePage());
        }


        private async void OnSignInLabelClicked(object sender, EventArgs e)
        {
            // Redirectează utilizatorul către pagina de autentificare (login).
            await Navigation.PushAsync(new HomePage());
        }
    }
}