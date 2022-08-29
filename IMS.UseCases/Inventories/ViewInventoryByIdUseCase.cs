using IMS.CoreBusiness;
using IMS.UseCases.Interfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.Inventories
{
    public class ViewInventoryByIdUseCase : IViewInventoryByIdUseCase
    {
        private readonly IInventoryRepository inventoryRespository;

        public ViewInventoryByIdUseCase(IInventoryRepository inventoryRespository)
        {
            this.inventoryRespository = inventoryRespository;
        }
        public async Task<Inventory?> ExecuteAsync(int inventoryId)
        {
            return await inventoryRespository.GetInventoryByIdAsync(inventoryId);

        }
    }
}
