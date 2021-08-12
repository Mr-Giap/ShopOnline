using ShopOnline.Aplication.ViewModel.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Utilsss;

namespace ShopOnline.Aplication.Interface.Admin
{
   public interface IBillService
    {
        Task<GenericResult> Add(BillViewModel bill);
         Task<GenericResult> Update(BillViewModel bill);
        PageResult<BillViewModel> GetAllPagging(string keyword, int pageSize, int pageIndex);
        GenericResult Remove(int id);
        Task<GenericResult> FindById(int id);
    }
}
