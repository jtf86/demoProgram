using System.Collections.Generic;
using Mall.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mall.Controllers
{
    public class StoresController : Controller
    {
        [HttpGet("/stores")]
        public ActionResult Index()
        {
            return View(Store.GetAll());
        }

        [HttpGet("/stores/add")]
        public ActionResult CreateForm()
        {
            return View();
        }

        [HttpPost("/stores/add")]
        public ActionResult Create(string name, int productId)
        {
            Store newStore = new Store(name, 1, productId);
            newStore.Save();
            return RedirectToAction("Index");
        }
    }
}