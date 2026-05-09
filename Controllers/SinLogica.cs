using Albergue_aspnet_DAS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Albergue_aspnet_DAS.Controllers
{
    public class SinLogica : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult ComoAdoptar()
        {
            
            return View();
        }


    }
}
