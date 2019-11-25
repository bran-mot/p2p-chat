using System;
using System.ComponentModel.DataAnnotations;

namespace p2pchat.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public string Sender { get; set; }
        public string Text { get; set; }
        public DateTime Timestamp { get; set; }

        public Message()
        {
            Timestamp = DateTime.Now;
            Id = new Random().Next(1000000, 9999999);
        }
    }
}
