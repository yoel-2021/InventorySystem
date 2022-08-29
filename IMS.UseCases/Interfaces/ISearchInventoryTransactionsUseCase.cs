using IMS.CoreBusiness;

namespace IMS.UseCases.Interfaces
{
    public interface ISearchInventoryTransactionsUseCase
    {
        Task<IEnumerable<InventoryTransaction>> ExecuteAsync(string inventoryName, DateTime? dateForm, DateTime? dateTo, InventoryTransactionType? transactionType);
    }
}