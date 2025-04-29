using DataAccess.Entities;

namespace Freelance_Platform_Api.Models
{
    public class CreateProjectModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public decimal Budget { get; set; }

        public ProjectStatus Status { get; set; }

        public string Сategory { get; set; }

        public int ClientId { get; set; }


        public int? FreelancerId { get; set; }
    }
}
