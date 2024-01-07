using Microsoft.Maui.Controls;
using Proiect_abonamente.Data;
using Proiect_abonamente.Models;
using System.IO;

namespace Proiect_abonamente
{
    public partial class App : Application
    {
        private static SubscriptionsDatabase _database;

        public App()
        {
            InitializeComponent();

            try
            {
                
                InitializeDatabase();

                MainPage = new AppShell();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception during database initialization: {ex}");
               
                Console.WriteLine(ex.ToString());
            }
        }

        public static SubscriptionsDatabase Database
        {
            get
            {
                if (_database == null)
                {
                  
                    string dataFolderPath = @"D:\Medii\Proiect_abonamente\Data";

                  
                    if (!Directory.Exists(dataFolderPath))
                    {
                        Directory.CreateDirectory(dataFolderPath);
                    }

                  
                    string dbPath = Path.Combine(dataFolderPath, "subscriptions.db3");

                    
                    _database = new SubscriptionsDatabase(dataFolderPath, "subscriptions.db3");
                }
                return _database;
            }
        }

        private void InitializeDatabase()
        {
           
        }

        public static Client LoggedInClient { get; private set; }

       
        public static void SetLoggedInClient(Client client)
        {
            LoggedInClient = client;

           
            if (client != null)
            {
                client.IsLoggedIn = true;
            }
        }
    }
}
