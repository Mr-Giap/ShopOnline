using ShopOnline.Aplication.ViewModel.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Utilsss;

namespace ShopOnline.Aplication.Interface.Admin
{
   public interface IUserService
    {
        Task<AppUserViewModel> Add(AppUserViewModel user);
        Task<AppUserViewModel> Update(AppUserViewModel user);
        PageResult<AppUserViewModel> GetAllPagging(string keyword,int pageSize,int pageIndex);
        void Remove(Guid id);
        Task<AppUserViewModel> FindById(Guid id);

    }
}
