using ShopOnline.Aplication.ViewModel.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Dtos;

namespace ShopOnline.Aplication.Interface.Admin
{
    public interface ITagService
    {
        Task<RepontResult> Add(TagViewModel tag);
        Task<RepontResult> Update(TagViewModel tag);
        PageResult<TagViewModel> GetAllPagging(string keyword, int pageSize, int pageIndex);
        Task<TagViewModel> GetById(int id);
        RepontResult Remove(int id);
    }
}
