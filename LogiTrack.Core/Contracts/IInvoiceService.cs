using LogiTrack.Core.ViewModels.Accountant;

namespace LogiTrack.Core.Contracts
{
    public interface IInvoiceService
    {
        Task<MarkAsPaidInvoiceViewModel?> GetInvoiceForPaymentAsync(int deliveryId);
        Task<List<InvoiceForDeliveryViewModel>> GetInvoicesAsync(string? deliveryReferenceNumber = null, DateTime? startDate = null, DateTime? endDate = null, string? companyName = null, bool? isPaid = null);
        Task<bool> InvoiceWithIdExistsAsync(int invoiceId);
        Task<int> MarkInvoiceAsPaidAsync(int id);
    }
}
