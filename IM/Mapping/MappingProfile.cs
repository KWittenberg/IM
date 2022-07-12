namespace IM.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // ApplicationUser
        CreateMap<ApplicationUser, ApplicationUserViewModel>();

        // Address
        CreateMap<Address, AddressViewModel>();

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

        // Order
        CreateMap<Order, OrderViewModel>();
    }
}