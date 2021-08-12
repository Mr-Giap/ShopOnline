using ShopOnline.Aplication.ViewModel.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Utilsss;

namespace ShopOnline.Aplication.Interface.Admin
{
  public  interface ICategoryService
    {
        Task<CategoryViewModel> Add(CategoryViewModel category);
       CategoryViewModel Update(CategoryViewModel category);
        PageResult<CategoryViewModel> GetAllPagging(string keyword, int pageSize, int pageIndex);
        Task<ProductViewModel> FindById(int id);
        void Remove(int id);
       
    }
}
