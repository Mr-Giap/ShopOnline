using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnlineWebAdmin.Controllers
{
    [Authorize] // Mọi action đều kiểm tra user đăng nhập mới thực hiện.
    public class BaseController : Controller
    {

        //[AllowAnonymous] // Cho phép User truy cập Action này mà không cần đăng nhập
        //public ActionResult Action1()
        //{
        //}
    }
}
