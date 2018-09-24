using Microsoft.AspNetCore.Mvc;
using Mall.Models;
using System.Collections.Generic;

namespace Mall.Controllers
{
    public class ProductsController : Controller
    {
        [HttpGet("/products")]
        public ActionResult Index()
        {
            return View(Product.GetAll());
        }

        [HttpGet("/products/add")]
        public ActionResult CreateForm()
        {
            return View();
        }

        [HttpPost("/products/add")]
        public ActionResult Create(string description)
        {
            Product newProduct = new Product(description);
            newProduct.Save();
            return RedirectToAction("Index");
        }
    }
}