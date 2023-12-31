﻿using System.Text.Json.Serialization;

namespace VebTech.Data.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
