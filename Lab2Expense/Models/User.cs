﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2Expense.Models
{


    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool isRemoved { get; set; }
        public DateTime DateAdded { get; set; }
        public IEnumerable<UserUserRole> UserUserRoles { get; set; }
    }
}
