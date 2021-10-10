using Microsoft.AspNetCore.Mvc;
using ShopOnline.Aplication.Interface.Admin;
using ShopOnline.Aplication.ViewModel.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnlineWebAdmin.Controllers
{
    public class SlideController : Controller
    {
        private readonly ISlideService _slideService;

        public SlideController(ISlideService slideService)
        {
            _slideService = slideService;
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
        [HttpPost]
        public async Task<IActionResult> Add(SlideViewModel slide)
        {
            var result = await _slideService.Add(slide);
            if (result != null)
            {
                return new OkObjectResult(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost]
        public async Task<IActionResult> Update(SlideViewModel slide)
        {
            var result = await _slideService.Update(slide);
            if (result != null)
            {
                return new OkObjectResult(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet]
        public IActionResult GetAllPagging(string keyword, int page, int pageSize)
        {
            var slide = _slideService.GetAllPagging(keyword, page, pageSize);
            if (slide != null)
            {
                return new OkObjectResult(slide);
            }
            return BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _slideService.GetById(id);
            if (result != null)
            {
                return new OkObjectResult(result);
            }
            return BadRequest();
        }
        [HttpDelete]
        public IActionResult Remove(int id)
        {
            var result = _slideService.Remove(id);
            if (result != null)
            {
                return Ok();
            }
            return BadRequest(result.Message);
        }
    }
}
