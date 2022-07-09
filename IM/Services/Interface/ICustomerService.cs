using IM.Models.ViewModel;

namespace IM.Services.Interface
{
    public interface ICustomerService
    {
        Task<AddressViewModel> GetAddress(string userId);

    }
}