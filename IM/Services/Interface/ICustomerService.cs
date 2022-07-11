namespace IM.Services.Interface;

public interface ICustomerService
{
    // AddressViewModel
    Task<AddressViewModel> GetAddress(string userId);

    // ApplicationUserViewModel
    Task<ApplicationUserViewModel> GetApplicationUser(string userId);
    Task<List<ApplicationUserViewModel>> GetApplicationUsers();
}