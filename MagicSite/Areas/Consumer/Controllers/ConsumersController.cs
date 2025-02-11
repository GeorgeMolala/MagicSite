using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicSite.Areas.Consumer.Controllers
{

  //  [Authorize (Roles = "Consumer")]
    [Area("Consumer")]
    public class ConsumersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
