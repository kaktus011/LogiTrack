using LogiTrack.Core.ViewModels.Accountant;
using LogiTrack.Core.ViewModels.Delivery;
using LogiTrack.Core.ViewModels.Driver;

namespace LogiTrack.Core.Contracts
{
    public interface IDeliveryService
    {
        Task<bool> DeliveryWithIdExistsAsync(int deliveryId);
        Task<int> GetDeliveryByReferenceNumberAsync(string referenceNumber);
        Task<DeliveryForDriverViewModel?> GetDeliveryDetailsForDriverAsync(int id);
        Task<List<DeliveryViewModel>?> GetDeliveriesForDriverBySearchtermAsync(string username, string? searchTerm);
        Task<bool> DriverHasDeliveryAsync(string username, int id);
        Task AddStatusForDeliveryAsync(int deliveryId, AddStatusViewModel model, string username, string address);
        Task<List<DeliveryViewModel>?> GetDeliveriesForDriverAsync(string username, string? referenceNumber = null, DateTime? endDate = null, DateTime? startDate = null, string? deliveryAddress = null, string? pickupAddress = null, bool? isNew = null);
        Task<DeliveryForAccountantViewModel> GetDeliveryDetailsForAccountantAsync(int id);
        Task<List<DeliveryViewModel>> GetDeliveryForAccountantAsync(string? referenceNumber, DateTime? endDate, DateTime? startDate, string? clientCompanyName, bool? isPaid);
        Task<List<DeliveryViewModel>> GetDeliveriesForAccountantBySearchtermAsync(string? searchTerm = null);
    }
}
