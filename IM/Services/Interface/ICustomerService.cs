namespace IM.Services.Interface
{
    public interface ICustomerService
    {
        Task<AddressViewModel> GetAddress(string userId);

        Task<ApplicationUserViewModel> GetApplicationUser(string userId);
        Task<List<ApplicationUserViewModel>> GetApplicationUsers();
    }
}