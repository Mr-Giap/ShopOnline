using ShopOnline.Aplication.ViewModel.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Utilsss;

namespace ShopOnline.Aplication.Interface.Admin
{
   public interface IColorService
    {
        Task<ColorViewModel> Add(ColorViewModel color);
       ColorViewModel Update(ColorViewModel color);
        PageResult<ColorViewModel> GetAllPagging(string keyword, int pageSize, int pageIndex);
        void Remove(int id);
        Task<ColorViewModel> FindById(int id);
    }
}
