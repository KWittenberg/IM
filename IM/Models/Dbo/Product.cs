using IM.Models.Base;
using IM.Models.Dbo.Base;

namespace IM.Models.Dbo
{
    public class Product : ProductBase, IEntityBase
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public ProductCategory ProductCategory { get; set; }

    }
}
