using Microsoft.AspNetCore.Mvc;
using ShopOnline.Aplication.Interface.Admin;
using ShopOnline.Aplication.ViewModel.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAdmin.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }
        public IActionResult Index()
        {
            ViewBag.Title = "Danh sách sản phẩm";
            return View();
        }
        [HttpGet]
        public IActionResult GetAllPagging(string keyword, int pageIndex,int pageSize)
        {
          var products=  _productService.GetAllPagging(keyword, pageSize, pageIndex);
            if (products != null)
            {
                return new OkObjectResult(products);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public async Task<IActionResult> FindById(int id)
        {
            var result = await _productService.FindById(id);
            if (result != null)
            {
                return new OkObjectResult(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
        [HttpPost]
        public async Task <IActionResult> Add(ProductViewModel product)
        {
            var result = await _productService.Add(product);
            if (result.Success)
            {
                result.Message = "add success";
                return new OkObjectResult(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
        [HttpPost]
        public  IActionResult Remove(int id)
        {
            var result =  _productService.Remove(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Update(ProductViewModel product)
        {
            var result = await _productService.Update(product);
            if (result.Success)
            {
                return new ObjectResult(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

    }
}
