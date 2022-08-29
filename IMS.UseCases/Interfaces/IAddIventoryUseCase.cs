using IMS.CoreBusiness;

namespace IMS.UseCases.Interfaces
{
    public interface IAddIventoryUseCase
    {
        Task ExecuteAsync(Inventory inventory);
    }
}