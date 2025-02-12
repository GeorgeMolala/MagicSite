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
    //[Route("api/[controller]/[action]")]
    //[ApiController]
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
            try
            {
                var resp = await _unit.Products.Add(product);
                 var t = 12;
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
            

          
        }


        [HttpPut]
        public async Task<ActionResult> UpdateProduct(ProductTbl product)
        {
            try
            {
                var resp = await _unit.Products.Update(product);
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
           
        }

        [HttpDelete]
        public async Task<ActionResult> SoftDeleteProduct(int ID)
        {
            try
            {
                var resp = await _unit.Products.SoftDelete(ID);

                return Ok();
            }
            catch
            {
                new ApplicationException("Something went wrong");

                return StatusCode(500);
            }
           
        }

        [HttpGet]
        public async Task<ActionResult<ProductTbl>> GetByProduct(int ID)
        {
            try
            {
                var resp = await _unit.Products.GetByID(ID);

                return resp;
            }
            catch
            {

                new ApplicationException("Something went wrong");

                return StatusCode(404);

            }

            return StatusCode(500);

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductTbl>>> GetAllProduct()
        {

            try
            {
                  var resp = await  _unit.Products.GetAll();

                  return resp.ToList();
            }
            catch
            {
                new ApplicationException("Something went wrong");
                return StatusCode(500);
            }
           
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }


        //Routung happens here
        [HttpGet]
        public IActionResult direcctions(string ID)
        {
            switch (ID)
            {
                case "1": return RedirectToAction("Index", "Consumers", new {Area = "Consumer" });

                case "2": return RedirectToActionPermanent("Index", "Shops", new { Area = "Shop" });

                case "3": return RedirectToAction("Index", "SiteOwners", new { Area = "SiteAdmin" });
            }

            return Content("No Selection made");
        }

        [HttpGet]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
