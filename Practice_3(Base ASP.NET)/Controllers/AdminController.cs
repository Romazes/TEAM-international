using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Practice_3_Base_ASP.NET_.Models;

namespace Practice_3_Base_ASP.NET_.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index() =>
            View(new SimpleViewModel(ProductMock.Baskets.Select(e =>
                 new SimpleViewItem(e.Id, e.Title, e.Amount,
                     Enum.GetName(typeof(ProductCategory), e.Category))).OrderBy(e => e.Id).ToList()));
    }
}