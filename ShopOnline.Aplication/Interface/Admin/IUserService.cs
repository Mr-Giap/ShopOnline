using ShopOnline.Aplication.ViewModel.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Dtos;

namespace ShopOnline.Aplication.Interface.Admin
{
    public interface IUserService
    {
        Task<AppUserViewModel> Add(AppUserViewModel user);
        Task<AppUserViewModel> Update(AppUserViewModel user);
        PageResult<AppUserViewModel> GetAllPagging(string keyword, int page, int pageSize); 
        Task<AppUserViewModel> GetById(Guid id);
        void Remove(Guid id);
    }
}
