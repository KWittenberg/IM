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
            CreateMap<ProductBinding, Product>();
            CreateMap<Product, ProductViewModel>();

            CreateMap<ProductCategoryBinding, ProductCategory>();
            CreateMap<ProductCategory, ProductCategoryViewModel>();
            CreateMap<ProductCategoryUpdateBinding, ProductCategory>();
        }
    }
}
