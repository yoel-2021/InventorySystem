﻿using IMS.CoreBusiness;
using IMS.UseCases.Interfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.Validations
{
    public class ValidateEnoughInventoriesForProducingUseCase : IValidateEnoughInventoriesForProducingUseCase
    {
        private readonly IProductRepository productRepository;

        public ValidateEnoughInventoriesForProducingUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task<bool> ExecuteAsync(Product product, int quantity)
        {
            var prod = await productRepository.GetProductsByIdAsync(product.ProductId);
            foreach (var pi in prod.ProductInventories)
            {
                if (pi.InventoryQuantity * quantity > pi.Inventory.Quantity)
                    return false;
            }
            return true;
        }
    }
}
