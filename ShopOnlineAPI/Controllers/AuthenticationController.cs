
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Aplication.Interface.Client;
using ShopOnline.Aplication.ViewModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utils.Dtos;

namespace ShopOnlineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : BaseController
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModelClient model)
        {
            if (!ModelState.IsValid)
            {
                var mes = new RepontResult();
                mes.Error = true;
                mes.Message = "Email false or Password required";
                return new BadRequestObjectResult(mes);
            }
            var result = await _authenticationService.Login(model);
            if (result.Success)
            {
                return new OkObjectResult(result.Data);
            }
            return new BadRequestObjectResult(result);
        }
    }
}
