namespace IM.Services.Interface;

public interface IProductService
{
    // ProductViewModel
    Task<ProductViewModel> GetProductAsync(int id);
    Task<List<ProductViewModel>> GetProductsAsync();
    Task<ProductViewModel> AddProductAsync(ProductBinding model);

    // ProductCategoryViewModel
    Task<ProductCategoryViewModel> GetProductCategoryAsync(int id);
    Task<List<ProductCategoryViewModel>> GetProductCategorysAsync();
    Task<ProductCategoryViewModel> AddProductCategoryAsync(ProductCategoryBinding model);
    Task<ProductCategoryViewModel> UpdateProductCategoryAsync(ProductCategoryUpdateBinding model);

    // ShoppingCartViewModel
    Task<ShoppingCartViewModel> GetShoppingCartAsync(string userId);
    Task<ShoppingCartViewModel> AddShoppingCartAsync(ShoppingCartBinding model);
}