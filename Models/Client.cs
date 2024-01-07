﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using SQLiteNetExtensions.Attributes;
using SQLite;

namespace Proiect_abonamente.Models
{
    public class Client
    {
        [PrimaryKey, AutoIncrement]
        public int ClientId{ get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public int Age{ get; set; }

        public bool IsLoggedIn { get; set; }




      
    }
}
