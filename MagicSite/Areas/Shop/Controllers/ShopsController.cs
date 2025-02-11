using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicSite.Areas.Shop.Controllers
{

   // [Authorize (Roles = "Shop")]
    [Area("Shop")]
    public class ShopsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
