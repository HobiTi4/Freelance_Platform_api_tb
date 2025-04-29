using DataAccess.Entities;

namespace Freelance_Platform_Api.Models
{
    public class CreateReviewModel
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
    }
}
