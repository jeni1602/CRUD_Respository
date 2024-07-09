using System.ComponentModel.DataAnnotations;

namespace CRUD_Respository.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = default!;

        [Required]
        [MaxLength(10)]
        public string Gender { get; set; } = default!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = default!;

        [Required]
        [MaxLength(10)]
        public string Pincode { get; set; } = default!;

        [Required]
        public bool IsActive { get; set; } = true;
    }
}
