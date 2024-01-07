using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proiect_abonamente.Models;
using SQLite;
using SQLiteNetExtensions.Attributes;



namespace Proiect_abonamente.Models
{
    public class Subscription
    {
        [PrimaryKey, AutoIncrement]
        public int SubscriptionId { get; set; }

        public decimal Price { get; set; }

        public TimeSpan Duration { get; set; }

       
        [Ignore]
        public int DurationInMonths
        {
            get { return (int)(Duration.TotalDays / 30); }
            set { Duration = TimeSpan.FromDays(value * 30); }
        }

        public DateTime Date { get; set; }

      
        [Ignore]
        public DateTime ExpirationDate
        {
            get { return Date.Add(Duration); }
        }

        [SQLiteNetExtensions.Attributes.ForeignKey(typeof(Client))]
        public int ClientId { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public Client Client { get; set; }
    }

}

