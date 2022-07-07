using IM.Models.Binding;
using IM.Models.ViewModel;

namespace IM.Services.Interface
{
    public interface IProductService
    {
        Task<ProductViewModel> AddProductAsync(ProductBinding model);
        Task<ProductViewModel> GetProductAsync(int id);
        Task<List<ProductViewModel>> GetProductsAsync();
        Task<ProductCategoryViewModel> UpdateProductCategoryAsync(ProductCategoryUpdateBinding model);
        Task<List<ProductCategoryViewModel>> GetProductCategorysAsync();
        Task<ProductCategoryViewModel> GetProductCategoryAsync(int id);
        Task<ProductCategoryViewModel> AddProductCategoryAsync(ProductCategoryBinding model);
    }
}