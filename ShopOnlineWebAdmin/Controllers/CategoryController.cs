﻿
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Aplication.Interface.Admin;
using ShopOnline.Aplication.ViewModel.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnlineWebAdmin.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(CategoryViewModel category)
        {
            var result = await _categoryService.Add(category);
            if (result != null)
            {
                return Ok();
            }
            return BadRequest(result.Message);
        }
        [HttpPost]
        public async Task<IActionResult> Update(CategoryViewModel category)
        {
            var record = await _categoryService.Update(category);
            if (record != null)
            {
                return Ok();
            }
            return BadRequest(record.Message);
        }
        [HttpGet]
        public IActionResult GetAllPagging(string keyword, int pageSize, int pageIndex)
        {
            var category = _categoryService.GetAllPagging(keyword, pageSize, pageIndex);
            if (category != null)
            {
                return new OkObjectResult(category);
            }
            return BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var takeId = await _categoryService.GetById(id);
            if (takeId !=null)
            {
                return new OkObjectResult(takeId);
            }
            return BadRequest();
        }
        [HttpDelete]
        public IActionResult Remove(int id)
        {
            var result = _categoryService.Remove(id);
            if (result != null)
            {
                return Ok();
            }
            return BadRequest(result.Message);
        }
    }
}
