using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Practice_3_Base_ASP.NET_.Models;

namespace Practice_3_Base_ASP.NET_.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index() =>
            View(new SimpleViewModel(ProductMock.Baskets.Select(e =>
        new SimpleViewItem(e.Id, e.Title, e.Amount,
            Enum.GetName(typeof(ProductCategory), e.Category))).OrderBy(e => e.Category).ToList()));

        public IActionResult RemoveProduct(int id)
        {
            if (ProductMock.Baskets.All(e => e.Id != id)) return RedirectToAction("Index");
            ProductMock.Baskets.Remove(ProductMock.Baskets.First(e => e.Id == id));
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("home/EditProduct/{id?}")]
        public IActionResult EditProduct(int id)
        {
            Positions2View();
            return ProductMock.Baskets.Any(e => e.Id == id)
                ? View(ProductMock.Baskets.First(e => e.Id == id))
                : (IActionResult)RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EditProduct([FromForm]Product product)
        {
            if (!ModelState.IsValid) return View();
            ProductMock.Baskets[ProductMock.Baskets.FindIndex(e => e.Id == product.Id)] = product;
            return RedirectToAction("Index");
        }

        public IActionResult AddProduct()
        {
            Positions2View();
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct([FromForm]Product product)
        {
            if (!ModelState.IsValid) return View();
            product.Id = ProductMock.Baskets.Max(e => e.Id) + 1;
            ProductMock.Baskets.Add(product);
            return RedirectToAction("Index");
        }

        private void Positions2View()
        {
            var list = new List<SelectListItem>();
            for (var i = 0; i < Enum.GetNames(typeof(ProductCategory)).Length; i++)
                list.Add(new SelectListItem { Text = Enum.GetName(typeof(ProductCategory), i), Value = i.ToString() });
            ViewBag.Category = new SelectList(list, "Value", "Text");
        }

    }
}