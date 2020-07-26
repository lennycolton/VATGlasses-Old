using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VATGlasses.Web.Controllers
{
    public class MapController : Controller
    {
        // GET: /Map/
        public IActionResult Index()
        {
            return View();
        }

        // GET: /Map/NumTimes/
        public string NumTimes(string name = "User", int numtimes = 1)
        {
            return $"Hello {name}, NumTimes is {numtimes}.";
        }
    }
}
