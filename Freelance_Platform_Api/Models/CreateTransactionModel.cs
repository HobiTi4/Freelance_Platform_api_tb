using DataAccess.Entities;

namespace Freelance_Platform_Api.Models
{
    public class CreateTransactionModel
    {

        public int UserId { get; set; }
        public decimal Amount { get; set; }

        public TransactionType Type { get; set; }

        public DateTime Date { get; set; }
    }
}
