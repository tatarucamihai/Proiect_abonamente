// SubscriptionView.cs
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Proiect_abonamente.Models;

namespace Proiect_abonamente.Views
{
    public class SubscriptionView : INotifyPropertyChanged
    {
        private ObservableCollection<Subscription> _subscriptions;

        public ObservableCollection<Subscription> Subscriptions
        {
            get { return _subscriptions; }
            set
            {
                _subscriptions = value;
                OnPropertyChanged(nameof(Subscriptions));
            }
        }

        public SubscriptionView()
        {
            InitializeAsync();
        }

        private async void InitializeAsync()
        {
            await LoadSubscriptionsAsync();
        }

        private async Task LoadSubscriptionsAsync()
        {
            var subscriptions = await App.Database.GetSubscriptionModelsAsync();
            Subscriptions = new ObservableCollection<Subscription>(subscriptions);
        }

        public async Task SaveSubscriptionAsync(Subscription subscription)
        {
            await App.Database.SaveSubscriptionModelAsync(subscription);
            await LoadSubscriptionsAsync(); // Reîmprospătează lista de abonamente după adăugare/modificare
        }

        public async Task DeleteSubscriptionAsync(Subscription subscription)
        {
            await App.Database.DeleteSubscriptionModelAsync(subscription);
            await LoadSubscriptionsAsync(); // Reîmprospătează lista de abonamente după ștergere
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
