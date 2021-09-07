﻿using AppLocationVehicleASP.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLocationVehicleASP.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Sex Sex { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public Role Role { get; set; }
        public string Token { get; set; }

    }
}
