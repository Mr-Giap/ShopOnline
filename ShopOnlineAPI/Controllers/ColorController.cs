using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Aplication.Interface.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnlineAPI.Controllers
{
    public class ColorController : BaseController
    {
        private readonly IColorServiceClient _colorServiceclient;
        public ColorController(IColorServiceClient _colorServiceclient)
        {
            _colorServiceclient = _colorServiceclient;
        }
        [HttpGet]
        public IActionResult Colors(string keyword, int page, int pageSize)
        {
            var colors = _colorServiceclient.GetAllPaggingClient(keyword, page, pageSize);
            if (colors != null)
            {
                return new OkObjectResult(colors);
            }
            return BadRequest();
        }
        [HttpPost]
        public IActionResult ColorId(int id)
        {
            try
            {
                var colorid = _colorServiceclient.GetById(id);
                if (colorid != null)
                {
                    return new OkObjectResult(colorid);
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return BadRequest();
        }
    }
}
