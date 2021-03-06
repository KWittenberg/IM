namespace IM.Models.ViewModel;

public class AddressViewModel : AddressBase
{
    public int Id { get; set; }

    // Relationships to ApplicationUser
    public ApplicationUserViewModel ApplicationUser { get; set; }
    public string ApplicationUserId { get; set; }
}