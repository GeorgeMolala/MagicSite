using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace MagicSite.Areas.SiteAdmin.Controllers
{

   // [Authorize(Roles = "SiteOwner") ]
    [Area("SiteOwner")]
    public class SiteOwnersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
