
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

            
            var existingUser = await App.Database.GetClientByEmailAsync(email);
            if (existingUser != null)
            {
                
                DisplayAlert("Error", "Email address is already registered.", "OK");
                return;
            }

           
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

            
            await Navigation.PushAsync(new HomePage());
        }


        private async void OnSignInLabelClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HomePage());
        }
    }
}