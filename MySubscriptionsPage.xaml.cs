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

            
            subscriptionsListView = new ListView();

           
            subscriptionsListView.ItemTemplate = new DataTemplate(() =>
            {
                var textCell = new TextCell();
                textCell.SetBinding(TextCell.TextProperty, "Descriere");
                textCell.SetBinding(TextCell.DetailProperty, "Data");
                return textCell;
            });

           
            var stackLayout = (StackLayout)Content;
            stackLayout.Children.Add(subscriptionsListView);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            
            var subscriptions = App.Database.GetSubscriptionModelsAsync().Result;
            subscriptionsListView.ItemsSource = new ObservableCollection<Subscription>(subscriptions);
        }
    }
}
