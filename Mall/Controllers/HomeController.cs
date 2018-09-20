using Microsoft.AspNetCore.Mvc;

namespace Mall.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            return View();
        }
    }
}