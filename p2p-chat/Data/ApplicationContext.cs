using System;
using Microsoft.EntityFrameworkCore;
using p2pchat.Models;

namespace p2pchat.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }
    }
}
