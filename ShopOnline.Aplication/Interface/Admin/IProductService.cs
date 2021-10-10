using ShopOnline.Aplication.ViewModel.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Dtos;

namespace ShopOnline.Aplication.Interface.Admin
{
    public interface IProductService
    {
        Task<RepontResult> Add(ProductViewModel product);
        Task<RepontResult> Update(ProductViewModel product);
        PageResult<ProductViewModel> GetAllPagging(string keyword, int page, int pageSize);
        Task<RepontResult> GetById(int id);
        RepontResult Remove(int id);
    }
}
