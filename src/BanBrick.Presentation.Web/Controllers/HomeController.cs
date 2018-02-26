using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BanBrick.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BanBrick.Presentation.WebSite.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(BanBrickMySqlContext context)
        {
            context.DeliveryServices.ToList();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
    }
}
