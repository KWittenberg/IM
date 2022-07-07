using IM.Models.Base;

namespace IM.Models.ViewModel
{
    public class ProductViewModel: ProductBase
    {
        public int Id { get; set; }
        public ProductCategoryViewModel ProductCategory { get; set; }
    }
}