using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice_3_Base_ASP.NET_.Models;

namespace Practice_3_Base_ASP.NET_.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public IActionResult Index() =>
            View(new SimpleViewModel(ProductMock.Baskets.Select(e =>
        new SimpleViewItem(e.Id, e.Title, e.Amount, 
            Enum.GetName(typeof(ProductCategory), e.Category))).OrderBy(e => e.Id).ToList()));

        //private void Positions2View()
        //{
        //    var list = new List<SelectListItem>();
        //    for (var i = 0; i < Enum.GetNames(typeof(Position)).Length; i++)
        //        list.Add(new SelectListItem { Text = Enum.GetName(typeof(Position), i), Value = i.ToString() });
        //    ViewBag.Positions = new SelectList(list, "Value", "Text");
        //}

    }
}