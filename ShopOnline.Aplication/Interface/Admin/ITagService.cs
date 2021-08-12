using ShopOnline.Aplication.ViewModel.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Utilsss;

namespace ShopOnline.Aplication.Interface.Admin
{
  public  interface ITagService
    {
        Task<TagViewModel> Add(TagViewModel tag);
        TagViewModel Update(TagViewModel tag);
        PageResult<TagViewModel> GetAllPagging(string keyword, int pageSize, int pageIndex);
        void Remove(int id);
        Task<TagViewModel> FindById(int id);
    }
}
