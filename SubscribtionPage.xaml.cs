using Microsoft.Maui.Controls;
using Proiect_abonamente.Models;
using System;
using Proiect_abonamente.Views;
using Proiect_abonamente.Data;

namespace Proiect_abonamente
{
    public partial class SubscribtionPage : ContentPage
    {
        private Subscription _subscription; 

        public SubscribtionPage()
        {
            InitializeComponent();
            _subscription = new Subscription();
            BindingContext = _subscription; // Instanta de subscribtion
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {

            var selectedDate = await DisplayPromptAsync("Selectați data", "Introduceți data abonamentului", "OK", "Anulați", null, -1, Keyboard.Default, DateTime.Now.ToString("d"));

            if (selectedDate == null)
                return; 

            if (!DateTime.TryParse(selectedDate, out DateTime subscriptionDate))
            {
                await DisplayAlert("Eroare", "Data introdusă nu este validă.", "OK");
                return; 
            }

            _subscription.Date = subscriptionDate;
            _subscription.DurationInMonths = 1;

            // Identificam clientul din baza de date
            Client loggedInClient = await App.Database.GetLoggedInClientAsync();

            if (loggedInClient == null)
            {
                
                await DisplayAlert("Not Logged In", "Trebuie să fii logat pentru a cumpăra abonamente.", "OK");
                return; 
            }

            if (loggedInClient != null)
            {
                
                _subscription.ClientId = loggedInClient.ClientId;

                try
                {
                    
                    await App.Database.SaveSubscriptionModelAsync(_subscription);
                    Console.WriteLine("Subscription saved successfully.");
                    await Navigation.PushAsync(new SubscribtionEntryPage());
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error saving subscription: {ex.Message}");
                    
                }
            }
            
        }

        private async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var subscription = (Subscription)BindingContext;

            
            await App.Database.DeleteSubscriptionModelAsync(subscription);

            await Navigation.PopAsync();
        }
    }
}
