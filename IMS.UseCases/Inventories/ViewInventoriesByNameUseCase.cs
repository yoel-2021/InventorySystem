using IMS.CoreBusiness;
using IMS.UseCases.Interfaces;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.Inventories
{
    public class ViewInventoriesByNameUseCase : IViewInventoriesByNameUseCase
    {
        private readonly IInventoryRepository inventoryRespository;
        public ViewInventoriesByNameUseCase(IInventoryRepository inventoryRespository)
        {
            this.inventoryRespository = inventoryRespository;
        }
        public async Task<IEnumerable<Inventory>> ExecuteAsync(string name = "")
        {
            return await inventoryRespository.GetInventoriesByName(name);

        }


    }
}