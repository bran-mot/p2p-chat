using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using p2pchat.Data;
using p2pchat.Models;

namespace p2pchat.Services
{
    public class MessageService
    {
        private ApplicationContext applicationContext;

        public MessageService(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public List<Message> GetMessages()
        {
            using (var db = applicationContext)
            {
                return db.Messages
                    .Include(m => m.Sender)
                    .ToList();
            }
        }

        public void SendMessage(string message)
        {
            using(var db = applicationContext)
            {
                db.Messages.Add(new Message(message));
                db.SaveChanges();
            }
        }

        public string CheckJsonFields(Message message)
        {
            string missingFields = "";
            foreach (PropertyInfo property in message.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (property.GetValue(message) == null)
                {
                    missingFields += property.Name + ", ";
                }
            }
            return missingFields;
        }
    }
}
