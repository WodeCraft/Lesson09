using MbmStore.Models;
using MbmStore.ViewModels;

namespace MbmStore.DAL
{
    public interface IInvoiceRepository
    {
        Product GetProductById(int productId);

        void SaveInvoice(Cart cart, ShippingDetails shippingDetails);
    }
}