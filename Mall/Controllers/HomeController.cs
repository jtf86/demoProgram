using Microsoft.AspNetCore.Mvc;

namespace Mall.Controllers
{
    public class HomeController : Controller
    {
        //Index route
        [HttpGet("/")]
        public ActionResult Index()
        {
            return View();
        }
    }
}