
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Aplication.Implement;
using ShopOnline.Aplication.Interface.Admin;
using ShopOnline.Aplication.ViewModel.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnlineWebAdmin.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;
       
        
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetAllPagging(string keyword, int pageSize, int pageIndex)
        {
            var products = _productService.GetAllPagging(keyword, pageSize, pageIndex);
            if (products != null)
            {
                return new OkObjectResult(products);
            }
            return BadRequest();
        }
        [HttpPost]
        public async Task<IActionResult>Add(ProductViewModel product)
        {
            var result = await _productService.Add(product);
            if (result != null)
            {
                return new OkObjectResult(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost]
        public async Task<IActionResult> Update(ProductViewModel product)
        {
            var result = await _productService.Update(product);
            if (result != null)
            {
                return new OkObjectResult(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet]
        public async Task<IActionResult>GetById(int id)
        {
            var result = await _productService.GetById(id);
            if (result != null)
            {
                return new OkObjectResult(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost]
        public IActionResult Remove(int id)
        {
            var result =  _productService.Remove(id);
            if (result != null)
            {
                return new OkObjectResult(result);
            }
            return BadRequest(result.Message);
        }


    }
}
