using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Server.Data.Models
{
    public class Inventory
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [Required]
        [StringLength(100, ErrorMessage = "Name length can't be more than 100.")]
        public string Name { get; set; } // Name of the inventory item

        [StringLength(500, ErrorMessage = "Description length can't be more than 500.")]
        public string Description { get; set; } // Description of the inventory item

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a non-negative number.")]
        public int Quantity { get; set; } // Quantity available in stock

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be a positive number.")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; } // Price of the inventory item

        // Foreign Key to Category
        [Required]
        public int CategoryId { get; set; }

        // Navigation property for the related Category
        public Category Category { get; set; }
    }
}
