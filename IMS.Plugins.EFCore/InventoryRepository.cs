using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace IMS.Plugins.EFCore
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly IMSContext db;

        public InventoryRepository(IMSContext db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<Inventory>> GetInventoriesByName(string name)
        {
            return await this.db.inventories.Where(x => x.InventoryName.ToLower().IndexOf(name.ToLower()) >= 0).ToListAsync();

            //return await this.db.inventories.Where(x => x.InventoryName.Contains(name, StringComparison.OrdinalIgnoreCase) ||
            //string.IsNullOrWhiteSpace(name)).ToListAsync();
        }

        public async Task AddInventoryAsync(Inventory inventory)
        {
            //para evitar diferentes inventarios con el mismo nombre
            if (db.inventories.Any(x => x.InventoryName.ToLower() == inventory.InventoryName.ToLower())) return;

            this.db.inventories.Add(inventory);
            await this.db.SaveChangesAsync();
        }

        public async Task UpdateInventoryAsync(Inventory inventory)
        {

            //if (db.inventories.Any(x=> x.InventoryId != inventory.InventoryId &&
            //                      x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase))) return ;

            if (db.inventories.Any(x=> x.InventoryId != inventory.InventoryId &&
                                  x.InventoryName.ToLower() == inventory.InventoryName.ToLower())) return ;

           var inv = await this.db.inventories.FindAsync(inventory.InventoryId);
           
            if (inv != null)
            {
                inv.InventoryName = inventory.InventoryName;
                inv.Price = inventory.Price;
                inv.Quantity = inventory.Quantity;

                await db.SaveChangesAsync();

            }

        }

        public async Task<Inventory?> GetInventoryByIdAsync(int inventoryId)
        {
            return await this.db.inventories.FindAsync(inventoryId);
        }
    }
}