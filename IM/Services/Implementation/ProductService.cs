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
        /// AddShoppingCartItem
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ShoppingCartItemViewModel> AddShoppingCartItemAsync(ShoppingCartItemBinding model)
        {
            var dbo = mapper.Map<ShoppingCartItem>(model);
            db.ShoppingCartItem.Add(dbo);
            await db.SaveChangesAsync();
            return mapper.Map<ShoppingCartItemViewModel>(dbo);
        }

        /// <summary>
        /// GetShoppingCartItem
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ShoppingCartItemViewModel> GetShoppingCartItemAsync(int id)
        {
            var dbo = await db.ShoppingCartItem.FindAsync(id);
            return mapper.Map<ShoppingCartItemViewModel>(dbo);
        }

        /// <summary>
        /// GetShoppingCartItems
        /// </summary>
        /// <returns></returns>
        public async Task<List<ShoppingCartItemViewModel>> GetShoppingCartItemsAsync()
        {
            var dbo = await db.ShoppingCartItem.ToListAsync();
            return dbo.Select(x => mapper.Map<ShoppingCartItemViewModel>(x)).ToList();
        }

        

        /// <summary>
        /// AddShoppingCart
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ShoppingCartViewModel> AddShoppingCartAsync(ShoppingCartBinding model)
        {
            var product = await db.Product.FindAsync(model.ProductId);
            product.Quantity -= model.Quantity;

            var user = await db.Users.FirstOrDefaultAsync(x => x.Id == model.UserId);
            if (product == null || user == null) { return null; }

            var shoppingCartItem = new ShoppingCartItem
            {
                Price = model.Price,
                Product = product,
                Quantity = model.Quantity
            };

            var dbo = new ShoppingCart
            {
                ShoppingCartItems = new List<ShoppingCartItem> { shoppingCartItem },
                ApplicationUser = user,
                ShoppingCartStatus = Models.ShoppingCartStatus.Pending
            };
            
            db.ShoppingCart.Add(dbo);
            await db.SaveChangesAsync();
            return mapper.Map<ShoppingCartViewModel>(dbo);
        }


        /// <summary>
        /// GetShoppingCartAsync by id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<ShoppingCartViewModel> GetShoppingCartAsync(string userId)
        {
            var shoppingCart = await db.ShoppingCart
                .Include(x => x.ShoppingCartItems)
                .ThenInclude(x => x.Product)
                .ThenInclude(x => x.ProductCategory)
                .FirstOrDefaultAsync(x => x.ApplicationUser.Id == userId && x.ShoppingCartStatus == Models.ShoppingCartStatus.Pending);
            return mapper.Map<ShoppingCartViewModel>(shoppingCart);
        }




    }
}
