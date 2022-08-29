using System.ComponentModel.DataAnnotations;

namespace Inventory_Management_System.ViewModels
{
    public class ProduceViewModel
    {
        [Required]

        public string ProductionNumber { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "La cantidad tiene que ser mayor que 1")]
        public int QuantityToProduce { get; set; }

        [Required]
        [Range(minimum: 0, maximum: int.MaxValue, ErrorMessage = "La cantidad tiene que ser mayor que 0")]
        public double ProductPrice { get; set; }
    }
}
