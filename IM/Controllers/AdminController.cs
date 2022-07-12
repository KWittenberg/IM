namespace IM.Controllers;

[Authorize(Roles = Roles.Admin)]
public class AdminController : Controller
{
    private readonly IProductService productService;

    public AdminController(IProductService productService)
    {
        this.productService = productService;
    }


    [HttpGet]
    public async Task<IActionResult> ProductAdministration()
    {
        var products = await productService.GetProductsAsync();
        return View(products);
    }


    public async Task<IActionResult> DetailsProduct(int id)
    {
        var product = await productService.GetProductAsync(id);

        return View(product);
    }



    /// <summary>
    /// Add Product
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> AddProduct()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct(ProductBinding model)
    {
        await productService.AddProductAsync(model);
        TempData["success"] = "Product created successfully";
        return RedirectToAction("ProductAdministration");
    }


    /// <summary>
    /// Edit Product
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> EditProduct(int id)
    {
        var product = await productService.GetProductAsync(id);
        return View(product);
    }
    
    [HttpPost]
    public async Task<IActionResult> EditProduct(ProductUpdateBinding model)
    {
        await productService.UpdateProductAsync(model);
        TempData["success"] = "Product update successfully";
        return RedirectToAction("ProductAdministration");
    }








    /// <summary>
    /// AddProductCategory
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> AddProductCategory()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddProductCategory(ProductCategoryBinding model)
    {
        await productService.AddProductCategoryAsync(model);
        TempData["success"] = "Product created successfully";
        return RedirectToAction("ProductAdministration");
    }





    /// <summary>
    /// Order
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> Order(int id)
    {
        var order = await productService.GetOrderAsync(id);
        return View(order);
    }

    /// <summary>
    /// Orders
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> Orders()
    {
        var orders = await productService.GetOrdersAsync();
        return View(orders);
    }
}