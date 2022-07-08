using IM.Models.Base;

namespace IM.Models.ViewModel
{
    public class ShoppingCartItemViewModel: ShoppingCartItemBase
    {
        public ProductViewModel Product { get; set; }
    }
}
