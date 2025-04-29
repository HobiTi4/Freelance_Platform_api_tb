using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Chat
    {
        public int ChatId { get; set; }

        public int SenderId { get; set; }
        public User Sender { get; set; }

        public int ReceiverId { get; set; }
        public User Receiver { get; set; }

        public string Content { get; set; }

        public DateTime SentAt { get; set; }
    }

}
