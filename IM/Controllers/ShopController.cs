namespace IM.Controllers;

//[Authorize (Roles = Roles.Admin)]
public class ShopController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IProductService productService;
    private readonly UserManager<ApplicationUser> userManager;

    public ShopController(ILogger<HomeController> logger, IProductService productService, UserManager<ApplicationUser> userManager)
    {
        _logger = logger;
        this.productService = productService;
        this.userManager = userManager;
    }

    public IActionResult Index()
    {
        return View(productService.GetProductsAsync().Result);
    }

    [Authorize]
    public async Task<IActionResult> ItemView(int id)
    {
        var product = await productService.GetProductAsync(id);

        return View(product);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> ItemView(ShoppingCartBinding model)
    {
        model.UserId = userManager.GetUserId(User);
        var product = await productService.AddShoppingCartAsync(model);

        return RedirectToAction("Index");
    }

    [Authorize]
    public async Task<IActionResult> ShoppingCart()
    {
        var shoppingCart = await productService.GetShoppingCartAsync(userManager.GetUserId(User));
        return View(shoppingCart);
    }
}