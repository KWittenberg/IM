using IM.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using IM.Models.Dbo;
using IM.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace IM.Controllers
{
    //[Authorize (Roles = Roles.Admin)]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService productService;
        
        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            this.productService = productService;
        }


        public IActionResult Index()
        {
            return View(productService.GetProductsAsync().Result);
        }

        public async Task<IActionResult> ItemView(int id)
        {
            var product = await productService.GetProductAsync(id);

            return View(product);
        }





        public IActionResult Privacy()
        {
            return View();
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}