
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class LoginEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(125)")]
        public string Email { get; set; } = null!;

        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Password { get; set; } = null!;

        public int UserId { get; set; }
        public UserEntity User { get; set; } = null!;
    }
}
