using ShopOnline.Aplication.ViewModel.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Dtos;

namespace ShopOnline.Aplication.Interface.Admin
{
    public  interface ISlideService
    {
        Task<RepontResult> Add(SlideViewModel slide);
        Task<RepontResult> Update(SlideViewModel slide);
        PageResult<SlideViewModel> GetAllPagging(string keyword, int pageSize, int pageIndex);
        Task<SlideViewModel> GetById(int id);
        RepontResult Remove(int id);
    }
}
