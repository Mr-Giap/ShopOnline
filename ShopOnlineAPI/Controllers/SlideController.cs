using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Aplication.Interface.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnlineAPI.Controllers
{
    public class SlideController : BaseController
    {
        private readonly ITagServiceClient _slideServiceclient;
        public SlideController(ITagServiceClient slideServiceclient)
        {
            _slideServiceclient = slideServiceclient;
        }
        [HttpGet]
        public IActionResult Slide(string keyword, int page, int pageSize)
        {
            var slide = _slideServiceclient.GetAllPaggingClient(keyword, page, pageSize);
            if (slide != null)
            {
                return new OkObjectResult(slide);
            }
            return BadRequest();
        }
    }
}
