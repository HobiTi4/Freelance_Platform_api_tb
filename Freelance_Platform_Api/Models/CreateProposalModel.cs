using DataAccess.Entities;

namespace Freelance_Platform_Api.Models
{
    public class CreateProposalModel
    {
        public int FreelancerId { get; set; }
        public int ProjectId { get; set; }
        public decimal ProposedPrice { get; set; }
        public DateTime SubmittedAt { get; set; }
    }
}
