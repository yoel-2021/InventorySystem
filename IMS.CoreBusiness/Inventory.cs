using System.ComponentModel.DataAnnotations;

namespace IMS.CoreBusiness
{
    public class Inventory
    {
        public int InventoryId { get; set; }
       
        [Required]
        public string? InventoryName { get; set; }

        [Range(0, int.MaxValue, ErrorMessage ="La cantidad debe ser igual o mayor que 0")]
        public int Quantity { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser igual o mayor que 0")]
        public double Price { get; set; }

        public List<ProductInventory>? ProductInventories { get; set; }
    }
}