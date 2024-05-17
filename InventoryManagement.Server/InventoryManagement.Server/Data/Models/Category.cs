using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Server.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [Required]
        [StringLength(100, ErrorMessage = "Name length can't be more than 100.")]
        public string Name { get; set; } // Category Name

        [StringLength(500, ErrorMessage = "Description length can't be more than 500.")]
        public string Description { get; set; } // Optional description of the category

        // Navigation property to link the category with its inventories
        public ICollection<Inventory> Inventories { get; set; }

        public Category()
        {
            Inventories = new HashSet<Inventory>();
        }
    }
}
