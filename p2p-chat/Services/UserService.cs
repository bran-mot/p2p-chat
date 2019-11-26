using System;
using System.Linq;
using p2pchat.Data;
using p2pchat.Models;

namespace p2pchat.Services
{
    public class UserService
    {
        public static User CurrentUser { get; set; }
        private ApplicationContext applicationContext;

        public UserService(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public void Login(string username)
        {
            using(var db = applicationContext)
            {
                var checkUser = db.Users.FirstOrDefault(u => u.Username == username);
                if (checkUser != null)
                {
                    CurrentUser = checkUser;
                }
            }
        }
    }
}
