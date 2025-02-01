using MagicSite.Data.Repositories.Helper_Classes;
using MagicSite.Data.UnitOfWork;
using MagicSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MagicSite.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        // private IProduct _products;
        private readonly IUnitOfWork _unit;
        public HomeController(ILogger<HomeController> logger, IUnitOfWork unit)
        {
            _logger = logger;
            //  _products = products;
            _unit = unit;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> AddProduct(ProductTbl product)
        {

            // var resp = await _products.Add(product);
            var resp = await _unit.Products.Add(product);
            var t = 12;

            return Ok();
        }


        [HttpPut]
        public async Task<ActionResult> UpdateProduct(ProductTbl product)
        {
            //  var resp = await _products.Update(product);
            var resp = await _unit.Products.Update(product);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> SoftDeleteProduct(int ID)
        {
            var resp = await _unit.Products.SoftDelete(ID);

            return Ok();
        }

        [HttpGet]
        public async Task<ProductTbl> GetByProduct(int ID)
        {
            var resp = await _unit.Products.GetByID(ID);

            return resp;
        }

        [HttpGet]
        public Task<IEnumerable<ProductTbl>> GetAllProduct()
        {

            var resp =   _unit.Products.GetAll();

            return resp;
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
