﻿using IMS.CoreBusiness;
using System.ComponentModel.DataAnnotations;

namespace Inventory_Management_System.Shared.ViewModels
{
    public class PurchaseViewModel
    {
        [Required]
        
        public string PurchaseOrder { get; set; }

        [Required]
        public int InventoryId { get; set; }

        [Required]
        public string InventoryName { get; set; }

        [Required]
        [Range(minimum:1, maximum:int.MaxValue, ErrorMessage ="La cantidad tiene que ser mayor que 1")]
        public int QuantityToPurchase { get; set; }

        public double InventoryPrice { get; set; }
    }
}
