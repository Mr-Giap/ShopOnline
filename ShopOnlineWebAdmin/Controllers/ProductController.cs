
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
        // Tìm hiểu RESTful API :
        /*  GET (SELECT): Trả về một Resource hoặc một danh sách Resource.
         *  PUT (UPDATE): Cập nhật thông tin cho Resource.
         *  DELETE (DELETE): Xoá một Resource.
         *  POST (CREATE): Tạo mới một Resource.
         */
        [HttpGet]
        public IActionResult GetAllPagging(string keyword, int page, int pageSize)
        {
            var products = _productService.GetAllPagging(keyword, page, pageSize);
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
        [HttpDelete]
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
