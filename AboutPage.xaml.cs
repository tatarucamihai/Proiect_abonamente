using Microsoft.Maui.Controls;
using Proiect_abonamente.Models;

namespace Proiect_abonamente
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            UpdateEmailLabel(); 
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            UpdateEmailLabel(); 
        }

        private void UpdateEmailLabel()
        {
           
            Client loggedInClient = App.LoggedInClient;

            if (loggedInClient != null)
            {
                
                emailLabel.Text = $"Logged in as: {loggedInClient.Email}";
            }
            else
            {
               
                emailLabel.Text = "Not logged in";
            }
        }
    }
}
