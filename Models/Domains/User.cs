﻿namespace NZWalkTutorial.Models.Domains
{
    public class User
    {
        public Guid Id { get; set; } 
        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public List<string> Roles { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }


    }
}
