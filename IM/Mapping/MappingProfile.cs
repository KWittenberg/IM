using IM.Models.Binding;
using IM.Models.Dbo;
using IM.Models.ViewModel;
using AutoMapper;

namespace IM.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Product
            CreateMap<ProductBinding, Product>();
            CreateMap<Product, ProductViewModel>();

            // ProductCategory
            CreateMap<ProductCategoryBinding, ProductCategory>();
            CreateMap<ProductCategory, ProductCategoryViewModel>();
            CreateMap<ProductCategoryUpdateBinding, ProductCategory>();

            // ShoppingChartItem
            CreateMap<ShoppingChartItemBinding, ShoppingChartItem>();
            CreateMap<ShoppingChartItem, ShoppingChartItemViewModel>();
        }
    }
}
