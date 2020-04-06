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
        private IProductsService _service;
        public HomeController(IProductsService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Index() =>
            View(new SimpleViewModel(ProductMock.Baskets.Select(e =>
        new SimpleViewItem(e.Id, e.Title, e.Amount,
            Enum.GetName(typeof(ProductCategory), e.Category),
            Enum.GetName(typeof(ProductMetricUnits), e.MetricUnit))).OrderBy(e => e.Category).ToList()));



        public IActionResult RemoveProduct(int id)
        {
            if (ProductMock.Baskets.All(e => e.Id != id)) return RedirectToAction("Index");
            ProductMock.Baskets.Remove(ProductMock.Baskets.First(e => e.Id == id));
            return RedirectToAction("Index");
        }

        //[HttpGet]
        //[Route("home/DiscoverProduct/{id?}")]
        //public IActionResult DiscoverProduct(int id)
        //{
        //    return View(ProductMock.Baskets.Any(t => t.Id == id));
        //    //return ProductMock.Baskets.Any(e => e.Id == id)
        //    //    ? View(ProductMock.Baskets.First(e => e.Id == id))
        //    //    : (IActionResult)RedirectToAction("Index");
        //    //View(repository.Teas.Include(p => p.TeaImageCollections).FirstOrDefault(p => p.TeaID == TeaID));
        //}

        [Route("home/DiscoverProduct/{id?}")]
        public ViewResult DiscoverProduct(int id) =>
            View(ProductMock.Baskets.FirstOrDefault(p => p.Id == id));

        [HttpGet]
        [Route("home/EditProduct/{id?}")]
        public IActionResult EditProduct(int id)
        {
            Units2View();
            Positions2View();
            return ProductMock.Baskets.Any(e => e.Id == id)
                ? View(ProductMock.Baskets.First(e => e.Id == id))
                : (IActionResult)RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EditProduct([FromForm]Product product)
        {
            if (!ModelState.IsValid)
            {
                Units2View();
                Positions2View();
                return View();
            }
            ProductMock.Baskets[ProductMock.Baskets.FindIndex(e => e.Id == product.Id)] = product;
            return RedirectToAction("Index");
        }

        public IActionResult AddProduct()
        {
            Units2View();
            Positions2View();
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct([FromForm]Product product)
        {

            if (!ModelState.IsValid)
            {
                Units2View();
                Positions2View();
                return View(product);
            }
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

        private void Units2View()
        {
            var list = new List<SelectListItem>();
            for (var i = 0; i < Enum.GetNames(typeof(ProductMetricUnits)).Length; i++)
                list.Add(new SelectListItem { Text = Enum.GetName(typeof(ProductMetricUnits), i), Value = i.ToString() });
            ViewBag.MetricUnit = new SelectList(list, "Value", "Text");
        }

    }
}