using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Required(ErrorMessage = "Role name is required")]
        [StringLength(50)]
        public string RoleName { get; set; } = string.Empty;
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
