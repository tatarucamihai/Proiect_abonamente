using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using Proiect_abonamente.Models;
using System;
using Proiect_abonamente.Views;

namespace Proiect_abonamente
{
    public partial class MySubscriptionsPage : ContentPage
    {
      
        public MySubscriptionsPage()
        {
            InitializeComponent();

            // Inițializează subscriptionsListView
            subscriptionsListView = new ListView();

            // Adaugă un șablon de element pentru afișarea datelor în ListView
            subscriptionsListView.ItemTemplate = new DataTemplate(() =>
            {
                var textCell = new TextCell();
                textCell.SetBinding(TextCell.TextProperty, "Descriere");
                textCell.SetBinding(TextCell.DetailProperty, "Data");
                return textCell;
            });

            // Adaugă subscriptionsListView la StackLayout
            var stackLayout = (StackLayout)Content;
            stackLayout.Children.Add(subscriptionsListView);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Obțineți abonamentele din baza de date și adăugați-le la ListView
            var subscriptions = App.Database.GetSubscriptionModelsAsync().Result;
            subscriptionsListView.ItemsSource = new ObservableCollection<Subscription>(subscriptions);
        }
    }
}
