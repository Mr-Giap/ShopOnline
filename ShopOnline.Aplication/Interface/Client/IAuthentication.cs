using ShopOnline.Aplication.ViewModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Dtos;

namespace ShopOnline.Aplication.Interface.Client
{
     public interface IAuthenticationService
    {
        Task<RepontResult> Login(LoginModelClient model);
        UserModel GetUser(string token);
        string GenerateJwtToken(Guid id);
        Guid? ValidateJwtToken(string token);
    }
}
