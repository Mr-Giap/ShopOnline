using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Aplication.Interface.Admin;
using ShopOnline.Aplication.Interface.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnlineAPI.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductServiceClient _productServiceclient;
        public ProductController(IProductServiceClient productServiceClient)
        {
            _productServiceclient = productServiceClient;
        }
        [HttpGet]
        public IActionResult Products(string keyword, int page, int pageSize)
        {
            var products = _productServiceclient.GetAllPaggingClient(keyword, page, pageSize);
            if (products != null)
            {
                return new OkObjectResult(products);
            }
            return BadRequest();
        }
        [HttpPost]
        public IActionResult ProductId(int id)
        {
            try
            {
                var products = _productServiceclient.GetById(id);
                if (products != null)
                {
                    return new OkObjectResult(products);
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return BadRequest();
        }
        [HttpGet]
        public IActionResult ProductGetAll()
        {
            var products = _productServiceclient.GetAll();
            if (products != null)
            {
                return new OkObjectResult(products);
            }
            return BadRequest();
        }
    }
}
