using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagicSite.Data.UnitOfWork;
using MagicSite.Models;
using Microsoft.Extensions.Configuration;

namespace MagicSite.Areas.Consumer.Controllers
{

  //  [Authorize (Roles = "Consumer")]
    [Area("Consumer")]
    public class ConsumersController : Controller
    {

        private readonly IUnitOfWork _unit;
        private readonly IConfiguration _config;

        public ConsumersController(IUnitOfWork unit, IConfiguration config)
        {
            _unit = unit;
            _config = config;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var res = await _unit.ViewProductHigh.GetAll();
                return View(res.ToList());
            }
            catch
            {
                new ApplicationException("Something went wrong");
                return StatusCode(500);
            }

        }

        
        //public async Task<ActionResult<IEnumerable<ProductHighlights>>> MyProductHighLights()
        //{
        //    try
        //    {
        //        var resp = await _unit.ViewProductHigh.GetAll();
        //    }
        //    catch
        //    {
        //        new ApplicationException("Something went wrong");
        //        return StatusCode(500);
        //    }
        //}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductTbl>>> MyProductsList()
        {

            try
            {
                var resp = await _unit.Products.GetAll();

                return View(resp.ToList());
            }
            catch
            {
                new ApplicationException("Something went wrong");
                return StatusCode(500);
            }

        }
    }
}
