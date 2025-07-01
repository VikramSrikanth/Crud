using System.ComponentModel.DataAnnotations;

namespace Crud.Models
{
    public class user
    {
        [Key]
        public int UserId { get; set; }

        [StringLength(50)]
        public string Name { get; set; } = null!;


        [StringLength(50)]
        public string Email { get; set; } = null!;


        [StringLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;


        public DateTime RegistrationDate { get; set; }


        [StringLength(50)]

        public string RollType { get; set; } = null!;
    }
}
