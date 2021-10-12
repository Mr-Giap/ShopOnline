using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Aplication.Interface.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnlineAPI.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryServiceClient _categoryServiceclient;
        public CategoryController(ICategoryServiceClient categoryServiceClient)
        {
            _categoryServiceclient = categoryServiceClient;
        }
        [HttpGet]
        public IActionResult Category(string keyword, int page, int pageSize)
        {
            var category = _categoryServiceclient.GetAllPaggingClient(keyword, page, pageSize);
            if (category != null)
            {
                return new OkObjectResult(category);
            }
            return BadRequest();
        }
        [HttpPost]
        public IActionResult CategoryId(int id)
        {
            try
            {
                var category = _categoryServiceclient.GetById(id);
                if (category != null)
                {
                    return new OkObjectResult(category);
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
            var categories = _categoryServiceclient.GetAll();
            if (categories != null)
            {
                return new OkObjectResult(categories);
            }
            return BadRequest();
        }
    }
}
