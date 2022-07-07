using IM.Models.Base;
using IM.Models.Dbo.Base;

namespace IM.Models.Dbo
{
    public class ShoppingChart: ShoppingChartBase, IEntityBase
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public ICollection<ShoppingChartItem> ShoppingChartItems { get; set; }
    }
}
