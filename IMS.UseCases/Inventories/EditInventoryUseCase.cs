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
    public class EditInventoryUseCase : IEditInventoryUseCase
    {
        private readonly IInventoryRepository inventoryRespository;

        public EditInventoryUseCase(IInventoryRepository inventoryRespository)
        {
            this.inventoryRespository = inventoryRespository;
        }
        public async Task ExecuteAsync(Inventory inventory)
        {
            await inventoryRespository.UpdateInventoryAsync(inventory);
        }
    }
}
