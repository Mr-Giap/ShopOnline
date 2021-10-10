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
        // Mỗi thằng admin là phải đăng nhập. Mỗi 1 lần đăng nhập thì cần Authorize  để đăng nhập.
        //  BaseController giúp cho kế thừa lại Authorize 
    }
}
