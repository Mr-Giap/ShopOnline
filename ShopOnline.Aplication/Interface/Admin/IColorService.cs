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
        Task<GenericResult> Add(ColorViewModel color);
        Task<GenericResult> Update(ColorViewModel color);
        PageResult<ColorViewModel> GetAllPagging(string keyword, int pageSize, int pageIndex);
        GenericResult Remove(int id);
        Task<ColorViewModel> FindById(int id);
    }
}
