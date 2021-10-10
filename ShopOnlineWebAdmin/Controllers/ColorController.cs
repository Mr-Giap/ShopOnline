using Microsoft.AspNetCore.Mvc;
using ShopOnline.Aplication.Interface.Admin;
using ShopOnline.Aplication.ViewModel.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnlineWebAdmin.Controllers
{
    public class ColorController : Controller
    {
        private readonly IColorService _colorService;

        public ColorController(IColorService colorService)
        {
            _colorService = colorService;
        }
        // Tìm hiểu RESTful API :
        /*  GET (SELECT): Trả về một Resource hoặc một danh sách Resource.
         *  PUT (UPDATE): Cập nhật thông tin cho Resource.
         *  DELETE (DELETE): Xoá một Resource.
         *  POST (CREATE): Tạo mới một Resource.
         */
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(ColorViewModel color)
        {
            var result = await _colorService.Add(color);
            if (result != null)
            {
                return new OkObjectResult(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost]
        public async Task<IActionResult> Update(ColorViewModel color)
        {
            var result = await _colorService.Update(color);
            if (result != null)
            {
                return new OkObjectResult(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet]
        public IActionResult GetAllPagging(string keyword, int pageSize, int pageIndex)
        {
            var color = _colorService.GetAllPagging(keyword, pageSize, pageIndex);
            if (color != null)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var record = await _colorService.GetById(id);
            if (record != null)
            {
                return new OkObjectResult(record);
            }
            return BadRequest();
        }
        [HttpDelete]
        public IActionResult Remove(int id)
        {
            var result = _colorService.Remove(id);
            if (result != null)
            {
                return Ok();
            }
            return BadRequest(result.Message);
        }
    }
}
