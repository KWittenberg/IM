using IM.Models.Base;

namespace IM.Models.Binding
{
    public class ShoppingCartBinding: ShoppingCartBase
    {
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public string UserId { get; set; }
    }
}
