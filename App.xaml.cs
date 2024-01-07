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
                // Inițializează baza de date
                InitializeDatabase();

                MainPage = new AppShell();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception during database initialization: {ex}");
                // Afișează excepția completă, inclusiv mesajul și urmele stivei
                Console.WriteLine(ex.ToString());
            }
        }

        public static SubscriptionsDatabase Database
        {
            get
            {
                if (_database == null)
                {
                    // Modifică calea către directorul dorit
                    string dataFolderPath = @"D:\Medii\Proiect_abonamente\Data";

                    // Creează directorul dacă nu există
                    if (!Directory.Exists(dataFolderPath))
                    {
                        Directory.CreateDirectory(dataFolderPath);
                    }

                    // Combinează calea cu numele fișierului de bază de date
                    string dbPath = Path.Combine(dataFolderPath, "subscriptions.db3");

                    // Inițializează baza de date
                    _database = new SubscriptionsDatabase(dataFolderPath, "subscriptions.db3");
                }
                return _database;
            }
        }

        private void InitializeDatabase()
        {
            // Poți adăuga aici orice alte acțiuni necesare pentru inițializarea bazei de date
        }

        public static Client LoggedInClient { get; private set; }

        // Updated method to set the logged-in client and update IsLoggedIn property
        public static void SetLoggedInClient(Client client)
        {
            LoggedInClient = client;

            // Update IsLoggedIn property
            if (client != null)
            {
                client.IsLoggedIn = true;
            }
        }
    }
}
