using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Aplication.Interface.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnlineAPI.Controllers
{
    public class BillController : BaseController
    {
        private readonly IBillServiceClient _billServiceclient;
        public BillController(IBillServiceClient billServiceClient)
        {
            _billServiceclient = billServiceClient;
        }
        [HttpGet]
        public IActionResult Bill(string keyword, int page, int pageSize)
        {
            var bill = _billServiceclient.GetAllPaggingClient(keyword, page, pageSize);
            if (bill != null)
            {
                return new OkObjectResult(bill);
            }
            return BadRequest();
        }
    }
}
