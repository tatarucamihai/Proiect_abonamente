using System;
using Proiect_abonamente.Data;
using Proiect_abonamente.Models;

namespace Proiect_abonamente
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            Shell.Current.FlyoutIsPresented = false; // Ascunde meniul lateral la început
        }

        private bool IsLoggedIn()
        {
            //cineva este logat
            return App.LoggedInClient != null;
        }

        private async void OnContinueButtonClicked(object sender, EventArgs e)
        {
           
            if (IsLoggedIn())
            {
                await DisplayAlert("Already Logged In", "You are already logged in.", "OK");
                return;
            }

            
            string email = emailEntry.Text;
            string password = passwordEntry.Text;

           
            bool isAuthenticated = await ValidateLoginAsync(email, password);

            if (isAuthenticated)
            {
                
                App.SetLoggedInClient(await App.Database.GetClientByEmailAsync(email));

                
                App.LoggedInClient.IsLoggedIn = true;

                await App.Database.SaveClientModelAsync(App.LoggedInClient);

                await Shell.Current.GoToAsync("//About");

               
                Shell.Current.FlyoutIsPresented = true;
            }
            else
            {
                
                await DisplayAlert("Authentication Failed", "Invalid email or password.", "OK");
            }
        }

        private async Task<bool> ValidateLoginAsync(string email, string password)
        {
            // Obține clientul din baza de date pe baza adresei de email
            var client = await App.Database.GetClientByEmailAsync(email);

            // Verifică existența clientului și corectitudinea parolei
            return client != null && client.Password == password;
        }
    }
}
