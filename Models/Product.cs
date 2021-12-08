using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeMaster.Models
{
    public class Product
    {
        public enum ProductType
        {
            Drink,
            Food,
            Swag
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarChar(100)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "nvarChar(200)")]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public ProductType Type { get; set; }

        public static string [] AllTypes { get; } = new string[] {"Drink", "Food", "Swag"};
    }
}