using ShopOnline.Aplication.ViewModel.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Utilsss;

namespace ShopOnline.Aplication.Interface.Admin
{
   public interface ISlideService
    {
        Task<SlideViewModel> Add(SlideViewModel slide);
        SlideViewModel Update(SlideViewModel slide);
        PageResult<SlideViewModel> GetAllPagging(string keyword, int pageSize, int pageIndex);
        void Remove(int id);
        Task<SlideViewModel> FindById(int id);
    }
}
