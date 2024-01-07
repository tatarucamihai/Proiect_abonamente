using System;
using Proiect_abonamente.Data;
using Proiect_abonamente.Models;

namespace Proiect_abonamente
{
    public partial class LogoutPage : ContentPage
    {
        public LogoutPage()
        {
            InitializeComponent();
        }

        private async void OnLogoutButtonClicked(object sender, EventArgs e)
        {
            // Retrieve the logged-in client from the App class
            Client loggedInClient = App.LoggedInClient;

            if (loggedInClient != null)
            {
                // Set IsLoggedIn to false
                loggedInClient.IsLoggedIn = false;

                // Save the updated status to the database
                await App.Database.SaveClientModelAsync(loggedInClient);

                // Clear the logged-in client instance
                App.SetLoggedInClient(null);
            }

            // Navigate to the login page
            await Shell.Current.GoToAsync("//Login");

            // Hide the flyout menu
            Shell.Current.FlyoutIsPresented = false;
        }
    }
}
