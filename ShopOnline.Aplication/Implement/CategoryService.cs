using ShopOnline.Aplication.Interface.Admin;
using ShopOnline.Aplication.ViewModel.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Utilsss;
using AutoMapper;
using ShopOnline.Aplication.AutoMapper;
using ShopOnline.DataEF;

namespace ShopOnline.Aplication.Implement
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDBContext _context;
        private IMapper _mapper = AutoMapperConfig.RegisterMappings().CreateMapper();
        public CategoryService(AppDBContext context)
        {
            this._context = context;
        }
        public Task<CategoryViewModel> Add(CategoryViewModel category)
        {
            throw new NotImplementedException();
        }

        public Task<ProductViewModel> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public PageResult<CategoryViewModel> GetAllPagging(string keyword, int pageSize, int pageIndex)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryViewModel> Update(CategoryViewModel category)
        {
            throw new NotImplementedException();
        }

        CategoryViewModel ICategoryService.Update(CategoryViewModel category)
        {
            throw new NotImplementedException();
        }
    }
}
