using AutoMapper;
using AutoMapper.QueryableExtensions;
using ShopOnline.Aplication.Automapper;
using ShopOnline.Aplication.Interface.Admin;
using ShopOnline.Aplication.ViewModel.Admin;
using ShopOnline.Data.Entities;
using ShopOnline.DataEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Dtos;

namespace ShopOnline.Aplication.Implement
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;
        private IMapper _maper = AutoMapperConfig.RegisterMappings().CreateMapper();
       
        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<RepontResult> Add(CategoryViewModel category)
        {
            var resultAdd = new RepontResult();
            var newCategory = new Category()
            {
               Name = category.Name,
               ParentId = category.ParentId,
               IsShow = category.IsShow,
               DateCreated = DateTime.Now,
               DisplayOrder = category.DisplayOrder,
               SeoDescription = category.SeoDescription,
               SeoKeyWord = category.SeoKeyWord,
               SeoTitle =category.SeoTitle

            };
            _context.Categories.Add(newCategory);
            await _context.SaveChangesAsync();
            resultAdd.Success = true;
            return resultAdd;

        }

        public PageResult<CategoryViewModel> GetAllPagging(string keyword, int pageSize, int pageIndex)
        {
            var category = _context.Categories.ProjectTo<CategoryViewModel>(AutoMapperConfig.RegisterMappings());
            if (!string.IsNullOrEmpty(keyword))
            {
                category = category.Where(x => x.Name.Contains(keyword) || x.ParentId.Contains(keyword) || x.SeoDescription.Contains(keyword) || x.SeoDescription.Contains(keyword) || x.SeoTitle.Contains(keyword));
            }
            int totalRow = category.Count();
            category = category.Skip((pageSize - 1) * pageIndex)
                .Take(pageSize);
            var result = new PageResult<CategoryViewModel>()
            {
                Results = category.ToList(),
                CurrentPage = pageIndex, // page hien tai
                PageSize = pageSize,
                RowCount = totalRow
            };
            return result;
        }

        public async Task<CategoryViewModel> GetById(int id)
        {
            var takeId = await _context.Categories.FindAsync(id);
            if (takeId != null)
            {
                return _maper.Map<Category, CategoryViewModel>(takeId);
            }
            return null;
        }

        public RepontResult Remove(int id)
        {
            var result = new RepontResult();
            var record = _context.Categories.FirstOrDefault(x => x.Id == id);
            if (record != null)
            {
                _context.Categories.Remove(record);
                _context.SaveChanges();
                result.Success = true;
            }
            else
            {
                result.Success = false;
                result.Message = "Not Found id is category";
            }
            return result;
        }

        public async Task<RepontResult> Update(CategoryViewModel category)
        {
            var resultUpdate = new RepontResult();
            var record = _context.Categories.FirstOrDefault(x => x.Id == category.Id);
            if (record != null)
            {
                record.Name = category.Name;
                record.ParentId = category.ParentId;
                record.IsShow = category.IsShow;
                record.DisplayOrder = category.DisplayOrder;
                record.SeoDescription = category.SeoDescription;
                record.SeoTitle = category.SeoTitle;
                record.SeoKeyWord = category.SeoKeyWord;
                _context.Categories.Update(record);
                await _context.SaveChangesAsync();
                resultUpdate.Success = true;
                // return _mapper.Map<Product, ProductViewModel>(record);
            }
            else
            {
                resultUpdate.Success = false;
                resultUpdate.Message = "Not found is a update Product";
            }
            return resultUpdate;
        }
    }
}
