﻿using System.ComponentModel.DataAnnotations;

namespace WebApiTokenUser.Entity.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }
    }
}