using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DccyOrigination.Controllers.SystemAdm
{
    public class SysAdmController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}