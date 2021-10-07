using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Aplication.Interface.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnlineAPI.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;


        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public IActionResult Products(string keyword, int pageSize, int pageIndex)
        {
            var products = _productService.GetAllPagging(keyword, pageSize, pageIndex);
            if (products != null)
            {
                return new OkObjectResult(products);
            }
            return BadRequest();
        }
    }
}
