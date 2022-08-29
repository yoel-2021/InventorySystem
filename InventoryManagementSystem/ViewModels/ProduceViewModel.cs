using System.ComponentModel.DataAnnotations;

namespace Inventory_Management_System.ViewModels
{
    public class SellViewModel
    {
        [Required]

        public string SalesOrderNumber { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "La cantidad tiene que ser mayor que 1")]
        public int QuantityToSell { get; set; }

        public double ProductPrice { get; set; }
    }
}
