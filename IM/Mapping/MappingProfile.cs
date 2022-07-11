namespace IM.Mapping;

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

        // ShoppingCartItem
        CreateMap<ShoppingCartItemBinding, ShoppingCartItem>();
        CreateMap<ShoppingCartItem, ShoppingCartItemViewModel>();

        // ShoppingCart
        CreateMap<ShoppingCart, ShoppingCartViewModel>();

        // Address
        CreateMap<Address, AddressViewModel>();

        // ApplicationUser
        CreateMap<ApplicationUser, ApplicationUserViewModel>();
    }
}