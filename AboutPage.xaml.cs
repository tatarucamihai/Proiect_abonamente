using Microsoft.Maui.Controls;
using Proiect_abonamente.Models;

namespace Proiect_abonamente
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            UpdateEmailLabel(); // Inițializarea etichetei cu adresa de email la început
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            UpdateEmailLabel(); // Actualizarea etichetei la fiecare afișare a paginii
        }

        private void UpdateEmailLabel()
        {
            // Verificați dacă utilizatorul este autentificat și obțineți adresa de email
            Client loggedInClient = App.LoggedInClient;

            if (loggedInClient != null)
            {
                // Afișați adresa de email într-un label pe pagina "About"
                emailLabel.Text = $"Logged in as: {loggedInClient.Email}";
            }
            else
            {
                // Dacă nu este autentificat, ascundeți label-ul sau afișați un text implicit
                emailLabel.Text = "Not logged in";
            }
        }
    }
}
