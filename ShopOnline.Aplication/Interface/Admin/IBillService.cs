using ShopOnline.Aplication.ViewModel.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Dtos;

namespace ShopOnline.Aplication.Interface.Admin
{
    public interface IBillService
    {
        Task<RepontResult> Add(BillViewModel bil);
        Task<RepontResult> Update(BillViewModel bil);
        PageResult<BillViewModel> GetAllPagging(string keyword, int pageSize, int pageIndex);
        Task<BillViewModel> GetById(int id);
        RepontResult Remove(int id);
    }
}
