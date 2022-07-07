using IM.Data;
using IM.Models.Binding;
using IM.Models.Dbo;
using IM.Models.ViewModel;
using IM.Services.Interface;
using Microsoft.EntityFrameworkCore;
using AutoMapper;


namespace IM.Services.Implementation
{
    public class ProductService: IProductService
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;

        public ProductService(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        /// <summary>
        /// Add Product
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ProductViewModel> AddProductAsync(ProductBinding model)
        {
            var dbo = mapper.Map<Product>(model);
            var productCategory = await db.ProductCategory.FindAsync(model.ProductCategoryId);
            if (productCategory == null) { return null; }
            dbo.ProductCategory = productCategory;
            db.Product.Add(dbo);
            await db.SaveChangesAsync();
            return mapper.Map<ProductViewModel>(dbo);
        }

        /// <summary>
        /// Find Product by id-1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ProductViewModel> GetProductAsync(int id)
        {
            var dbo = await db.Product.Include(x => x.ProductCategory).FirstOrDefaultAsync(x => x.Id == id);
            return mapper.Map<ProductViewModel>(dbo);
        }

        /// <summary>
        /// Find All Products
        /// </summary>
        /// <returns></returns>
        public async Task<List<ProductViewModel>> GetProductsAsync()
        {
            var dbo = await db.Product.ToListAsync();
            return dbo.Select(x => mapper.Map<ProductViewModel>(x)).ToList();
        }

        /// <summary>
        /// Add Category Product
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ProductCategoryViewModel> AddProductCategoryAsync(ProductCategoryBinding model)
        {
            var dbo = mapper.Map<ProductCategory>(model);
            db.ProductCategory.Add(dbo);
            await db.SaveChangesAsync();
            return mapper.Map<ProductCategoryViewModel>(dbo);
        }

        /// <summary>
        /// Find Category Product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ProductCategoryViewModel> GetProductCategoryAsync(int id)
        {
            var dbo = await db.ProductCategory.FindAsync(id);
            return mapper.Map<ProductCategoryViewModel>(dbo);
        }

        /// <summary>
        /// Find All Category Product
        /// </summary>
        /// <returns></returns>
        public async Task<List<ProductCategoryViewModel>> GetProductCategorysAsync()
        {
            var dbo = await db.ProductCategory.ToListAsync();
            return dbo.Select(x => mapper.Map<ProductCategoryViewModel>(x)).ToList();
        }

        /// <summary>
        /// UpdateProductCategory
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ProductCategoryViewModel> UpdateProductCategoryAsync(ProductCategoryUpdateBinding model)
        {
            var dbo = await db.ProductCategory.FindAsync(model.Id);
            mapper.Map(model, dbo);
            await db.SaveChangesAsync();
            return mapper.Map<ProductCategoryViewModel>(dbo);
        }



        /// <summary>
        /// AddShoppingChartItem
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ShoppingChartItemViewModel> AddShoppingChartItemAsync(ShoppingChartItemBinding model)
        {
            var dbo = mapper.Map<ShoppingChartItem>(model);
            db.ShoppingChartItem.Add(dbo);
            await db.SaveChangesAsync();
            return mapper.Map<ShoppingChartItemViewModel>(dbo);
        }

        /// <summary>
        /// GetShoppingChartItem
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ShoppingChartItemViewModel> GetShoppingChartItemAsync(int id)
        {
            var dbo = await db.ShoppingChartItem.FindAsync(id);
            return mapper.Map<ShoppingChartItemViewModel>(dbo);
        }

        /// <summary>
        /// GetShoppingChartItems
        /// </summary>
        /// <returns></returns>
        public async Task<List<ShoppingChartItemViewModel>> GetShoppingChartItemsAsync()
        {
            var dbo = await db.ShoppingChartItem.ToListAsync();
            return dbo.Select(x => mapper.Map<ShoppingChartItemViewModel>(x)).ToList();
        }



    }
}
