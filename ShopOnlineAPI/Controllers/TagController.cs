using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Aplication.Interface.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnlineAPI.Controllers
{
    public class TagController : BaseController
    {
        private readonly ITagServiceClient _tagServiceclient;
        public TagController(ITagServiceClient tagServiceClient)
        {
            _tagServiceclient = tagServiceClient;
        }
        [HttpGet]
        public IActionResult Tag(string keyword, int page, int pageSize)
        {
            var tags = _tagServiceclient.GetAllPaggingClient(keyword, page, pageSize);
            if (tags != null)
            {
                return new OkObjectResult(tags);
            }
            return BadRequest();
        }
    }
}
