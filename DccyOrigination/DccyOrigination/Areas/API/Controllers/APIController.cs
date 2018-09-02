using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DccyOrigination.Areas.API.Controllers
{
    public class APIController : Controller
    {
        [Area("API")]
        public IActionResult Index()
        {
            return View();
        }
    }
}