using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeMaster.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarChar(100)")]
        public string Name { get; set; }

        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        public int Rewards { get; set; }

    }
}
