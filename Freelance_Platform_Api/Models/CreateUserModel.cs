using DataAccess.Entities;

namespace Freelance_Platform_Api.Models
{
    public class CreateUserModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int RoleID { get; set; } 
        public decimal? Balance { get; set; }
        public int Rating { get; set; }
    }
}
