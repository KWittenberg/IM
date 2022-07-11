namespace IM.Models.ViewModel;

public class ShoppingCartViewModel : ShoppingCartBase
{
    public int Id { get; set; }
    public List<ShoppingCartItemViewModel> ShoppingCartItems { get; set; }

    public ShoppingCartStatus ShoppingCartStatus { get; set; }
    public DateTime Created { get; set; }
}