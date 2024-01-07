using Microsoft.Maui.Controls;
using Proiect_abonamente.Models;
using System;
using System.Collections.Generic;

namespace Proiect_abonamente
{
    public partial class SubscribtionEntryPage : ContentPage
    {
        public SubscribtionEntryPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Retrieve the logged-in client from the App class
            Client loggedInClient = App.LoggedInClient;

            if (loggedInClient != null)
            {
                // Get subscriptions for the logged-in client
                List<Subscription> subscriptions = await App.Database.GetSubscriptionsByClientIdAsync(loggedInClient.ClientId);

                // Set the ListView's ItemsSource to the filtered subscriptions
                listView.ItemsSource = subscriptions;
            }
        }

        async void OnBuySubscriptionClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SubscribtionPage
            {
                BindingContext = new Subscription()
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new SubscribtionPage
                {
                    BindingContext = e.SelectedItem as Subscription
                });
            }
        }

        private async void OnSeeBenefitsClicked(object sender, EventArgs e)
        {
            // Retrieve the selected subscription from the button's binding context
            if (sender is Button button && button.BindingContext is Subscription selectedSubscription)
            {
                // Navigate to a page (e.g., "ClassesPage") and pass the selected subscription as a parameter
                await Navigation.PushAsync(new ClassesPage(selectedSubscription));
            }
        }

    }
}
