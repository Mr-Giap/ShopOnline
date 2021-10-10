using Microsoft.AspNetCore.Mvc;
using ShopOnline.Aplication.Interface.Admin;
using ShopOnline.Aplication.ViewModel.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnlineWebAdmin.Controllers
{

    public class BillController : BaseController
    {
        private readonly IBillService _billService;

        public BillController(IBillService billService)
        {
            this._billService = billService;
        }
        
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(BillViewModel bill)
        {
            var result = await _billService.Add(bill);
            if (result != null)
            {
                return new OkObjectResult(result);
            }
            return BadRequest(result.Message);
        }
        //[HttpPut]
        [HttpPost]
        public async Task<IActionResult> Update(BillViewModel bill)
        {
            var result = await _billService.Update(bill);
            if (result != null)
            {
                return new OkObjectResult(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet]
        public IActionResult GetAllPagging(string keyword, int page, int pageSize)
        {
            var bill = _billService.GetAllPagging(keyword, page, pageSize);
            if (bill != null)
            {
                return new OkObjectResult(bill);
            }
            return BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _billService.GetById(id);
            if (result != null)
            {
                return new OkObjectResult(result);
            }
            return BadRequest();
        }
        [HttpDelete]
        public IActionResult Remove(int id)
        {
            var result = _billService.Remove(id);
            if (result != null)
            {
                return Ok();
            }
            return BadRequest(result.Message);
        }
    }
}
