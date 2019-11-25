using System;
using System.ComponentModel.DataAnnotations;

namespace p2pchat.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }

        public User(string username)
        {
            Username = username;
        }
    }
}
