using ShopOnline.Aplication.ViewModel.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Dtos;

namespace ShopOnline.Aplication.Interface.Admin
{
    public interface ICategoryService
    {
        Task<RepontResult> Add(CategoryViewModel category);
        Task<RepontResult> Update(CategoryViewModel category);
        PageResult<CategoryViewModel> GetAllPagging(string keyword, int pageSize, int pageIndex);
        Task<CategoryViewModel> GetById(int id);
        RepontResult Remove(int id);

    }
}
