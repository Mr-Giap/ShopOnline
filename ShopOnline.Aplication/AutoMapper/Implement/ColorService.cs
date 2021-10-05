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
using ShopOnline.Data.Entities;
using AutoMapper.QueryableExtensions;

namespace ShopOnline.Aplication.Implement
{
    public class ColorService : IColorService
    {
        private readonly AppDBContext _context;
        private IMapper _mapper = AutoMapperConfig.RegisterMappings().CreateMapper();
        public ColorService(AppDBContext context)
        {
            this._context = context;
        }
        public async Task<GenericResult> Add(ColorViewModel color)
        {
            var result = new GenericResult();
            var newColor = new Color()
            {
                Name = color.Name
            };
            await _context.colors.AddAsync(newColor);
            await _context.SaveChangesAsync();
            var colordb = _context.colors.FirstOrDefault();
            result.Success = true;
            return result;
        }

        public Task<ColorViewModel> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public PageResult<ColorViewModel> GetAllPagging(string keyword, int pageSize, int pageIndex)
        {
            var colors = _context.colors.ProjectTo<ColorViewModel>(AutoMapperConfig.RegisterMappings());
            if (!string.IsNullOrEmpty(keyword))
            {
                colors = colors.Where(x => x.Name.Contains(keyword));
            }
            int totalRow = colors.Count();
            colors = colors.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            var result = new PageResult<ColorViewModel>()
            {
                Results = colors.ToList(),
                CurrentPage = pageIndex,
                PageSize = pageSize,
                RowCount = totalRow
            };
            return result;
        }

        public GenericResult Remove(int id)
        {
            var result = new GenericResult();
            var color = _context.colors.FirstOrDefault(x => x.Id == id);
            if (color != null)
            {
                _context.colors.Remove(color);
                _context.SaveChanges();
                result.Success = true;
            }
            else
            {
                result.Success = false;
                result.Message = "Không tìm thấy màu";
            }
          return   result;
        }

        public async Task<GenericResult> Update(ColorViewModel color)
        {
            var result = new GenericResult();
            var updateColor = _context.colors.FirstOrDefault(x => x.Id == color.Id);
            
            if(updateColor!=null)
            {
                updateColor.Name = color.Name;

                _context.colors.Update(updateColor);
                await _context.SaveChangesAsync();
                result.Success = true;
            }
            else
            {
                result.Success = false;
                result.Message = "Không tìm thấy màu";
            }
            return result;
        }

        //ColorViewModel IColorService.Update(ColorViewModel color)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
