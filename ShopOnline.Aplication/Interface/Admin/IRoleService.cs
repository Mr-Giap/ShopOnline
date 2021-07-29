
using ShopOnline.Aplication.ViewModel.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Dtos;

namespace ShopOnline.Aplication.Interface.Admin
{
    public interface IRoleService
    {
        Task<AppRoleViewModel> Add(AppRoleViewModel role);
        Task<AppRoleViewModel> Update(AppRoleViewModel role);
        PageResult<AppRoleViewModel> GetAllPagging(string keyword, int pageSize, int pageIndex);
        Task<AppRoleViewModel> GetById(Guid id);
        void Remove(Guid id);
    }
}
