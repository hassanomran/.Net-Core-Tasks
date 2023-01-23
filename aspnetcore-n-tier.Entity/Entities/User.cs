using System.ComponentModel.DataAnnotations;

namespace aspnetcore_n_tier.Entity.Entities
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int RoleId { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public Role role { get; set; }
    }
}
