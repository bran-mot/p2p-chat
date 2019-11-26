using System;
using System.ComponentModel.DataAnnotations;
using p2pchat.Services;

namespace p2pchat.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Timestamp { get; set; }

        public User Sender { get; set; }
        public int SenderId { get; set; }

        public Message()
        {

        }

        public Message(string text)
        {
            Text = text;
            SenderId = UserService.CurrentUser.Id;
            Timestamp = DateTime.Now;
            Id = new Random().Next(1000000, 9999999);
        }

        public Message(int id, string text, int senderId, string timestamp)
        {
            Id = id;
            Text = text;
            Timestamp = Convert.ToDateTime(timestamp);
            SenderId = senderId;
        }
    }
}
