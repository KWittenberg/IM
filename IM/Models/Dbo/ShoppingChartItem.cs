using IM.Models.Base;
using IM.Models.Dbo.Base;

namespace IM.Models.Dbo
{
    public class ShoppingCartItem: ShoppingCartItemBase, IEntityBase
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public Product Product { get; set; }
    }
}
