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

        // Add this method to check if someone is logged in
        private bool IsLoggedIn()
        {
            // Check if the logged-in client in the App class is not null, indicating that someone is logged in
            return App.LoggedInClient != null;
        }

        private async void OnContinueButtonClicked(object sender, EventArgs e)
        {
            // If someone is already logged in, you might not want to perform another login
            if (IsLoggedIn())
            {
                await DisplayAlert("Already Logged In", "You are already logged in.", "OK");
                return;
            }

            // Obține valorile introduse pentru email și parolă
            string email = emailEntry.Text;
            string password = passwordEntry.Text;

            // Validează autentificarea (poți adăuga logica ta specifică)
            bool isAuthenticated = await ValidateLoginAsync(email, password);

            if (isAuthenticated)
            {
                // După autentificare, setează _loggedInClient în clasa App
                App.SetLoggedInClient(await App.Database.GetClientByEmailAsync(email));

                // Set IsLoggedIn property to true
                App.LoggedInClient.IsLoggedIn = true;

                await App.Database.SaveClientModelAsync(App.LoggedInClient);

                await Shell.Current.GoToAsync("//About");

                // După autentificare, afișează meniul lateral
                Shell.Current.FlyoutIsPresented = true;
            }
            else
            {
                // În cazul în care autentificarea eșuează, afișează un mesaj de eroare sau poți face alte acțiuni specifice
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
