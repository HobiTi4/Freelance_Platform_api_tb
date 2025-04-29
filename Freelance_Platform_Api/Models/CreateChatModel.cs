using DataAccess.Entities;

namespace Freelance_Platform_Api.Models
{
    public class CreateChatModel
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string Content { get; set; }
        public DateTime SentAt { get; set; }
    }
}
