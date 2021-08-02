
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnlineWebAdmin.Controllers
{
    public class CategoryController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
