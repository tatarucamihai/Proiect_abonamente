using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using Proiect_abonamente.Models;


namespace Proiect_abonamente.Data
{
    public class SubscriptionsDatabase
    {
        private readonly SQLiteAsyncConnection _database;

        public SubscriptionsDatabase(string dbDirectory, string dbName)
        {
            string fullPath = Path.Combine(dbDirectory, dbName);

            _database = new SQLiteAsyncConnection(fullPath);
            _database.ExecuteAsync("PRAGMA foreign_keys = ON;");
            _database.CreateTableAsync<Subscription>().Wait();
            _database.CreateTableAsync<Client>().Wait();
        }

        public SQLiteAsyncConnection GetDatabaseConnection()
        {
            return _database;
        }

        public Task<List<Subscription>> GetSubscriptionModelsAsync()
        {
            return _database.Table<Subscription>().ToListAsync();
        }

        public Task<Subscription> GetSubscriptionModelAsync(int id)
        {
            return _database.Table<Subscription>()
                            .Where(i => i.SubscriptionId == id)
                            .FirstOrDefaultAsync();
        }
        

        

        public Task<int> SaveSubscriptionModelAsync(Subscription subscription)
        {
            if (subscription.SubscriptionId != 0)
            {
                return _database.UpdateAsync(subscription);
            }
            else
            {
                return _database.InsertAsync(subscription);
            }
        }

        public Task<int> DeleteSubscriptionModelAsync(Subscription subscription)
        {
            return _database.DeleteAsync(subscription);
        }


        public Task<List<Client>> GetClientsAsync()
        {
            return _database.Table<Client>().ToListAsync();
        }

        public Task<Client> GetClientByEmailAsync(string email)
        {
            return _database.Table<Client>()
                            .Where(c => c.Email == email)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveClientModelAsync(Client client)
        {
            if (client.ClientId != 0)
            {
                return _database.UpdateAsync(client);
            }
            else
            {
                return _database.InsertAsync(client);
            }
        }


        public Task<int> DeleteClientAsync(Client client)
        {
            return _database.DeleteAsync(client);
        }

        public async Task<int> RegisterClientAsync(Client client)
        {
            await _database.InsertAsync(client);
            return client.ClientId; 
        }

        public Task<Client> GetLoggedInClientAsync()
        {
            return _database.Table<Client>()
                            .Where(c => c.IsLoggedIn)
                            .FirstOrDefaultAsync();
        }

       
        public Task<List<Subscription>> GetSubscriptionsByClientIdAsync(int clientId)
        {
            return _database.Table<Subscription>()
                            .Where(s => s.ClientId == clientId)
                            .ToListAsync();
        }


    }
}
