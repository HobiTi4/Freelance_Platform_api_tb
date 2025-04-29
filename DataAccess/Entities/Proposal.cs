using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Proposal
    {
        public int ProposalId { get; set; }
        public int FreelancerId { get; set; }
        public User Freelancer { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public decimal ProposedPrice { get; set; }
        public DateTime SubmittedAt { get; set; }
    }
}
