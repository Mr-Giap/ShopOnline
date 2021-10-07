using Microsoft.AspNetCore.Mvc;
using ShopOnline.Aplication.Interface.Admin;
using ShopOnline.Aplication.ViewModel.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnlineWebAdmin.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(TagViewModel tag)
        {
            var result = await _tagService.Add(tag);
            if (result != null)
            {
                return new OkObjectResult(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost]
        public async Task<IActionResult> Update(TagViewModel tag)
        {
            var result = await _tagService.Update(tag);
            if (result != null)
            {
                return new OkObjectResult(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet]
        public IActionResult GetAllPagging(string keyword, int pageSize, int pageIndex)
        {
            var tag = _tagService.GetAllPagging(keyword, pageSize, pageIndex);
            if (tag != null)
            {
                return new OkObjectResult(tag);
            }
            return BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _tagService.GetById(id);
            if (result != null)
            {
                return new OkObjectResult(result);
            }
            return BadRequest();
        }
        [HttpDelete]
        public IActionResult Remove(int id)
        {
            var result = _tagService.Remove(id);
            if (result != null)
            {
                return Ok();
            }
            return BadRequest(result.Message);
        }
    }
}
