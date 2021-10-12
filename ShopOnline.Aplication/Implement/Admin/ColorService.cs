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
    public class ColorService : IColorService
    {
        private readonly AppDbContext _context;
        private IMapper _maper = AutoMapperConfig.RegisterMappings().CreateMapper();

        public ColorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<RepontResult> Add(ColorViewModel color)
        {
            var resutlAdd = new RepontResult();
            var newColor = new Color()
            {
                Name = color.Name
            };
            _context.Colors.Add(newColor);
            await  _context.SaveChangesAsync();
            resutlAdd.Success = true;
            return resutlAdd;
        }

        public PageResult<ColorViewModel> GetAllPagging(string keyword, int page, int pageSize)
        {
            var color = _context.Colors.ProjectTo<ColorViewModel>(AutoMapperConfig.RegisterMappings());
            if (!string.IsNullOrEmpty(keyword))
            {
                color = color.Where(x => x.Name.Contains(keyword));
            }
            int totalRow = color.Count();
            color = color.Skip((page - 1) * pageSize)
                .Take(pageSize);
            var result = new PageResult<ColorViewModel>()
            {
                Results = color.ToList(),
                CurrentPage = page, // page hien tai
                RowCount = totalRow ,
                PageSize = pageSize
            };
            return result;
        }

        public async Task<RepontResult> GetById(int id)
        {
            var takeId = await _context.Colors.FindAsync(id);
            var resultId = new RepontResult();
            if (takeId != null)
            {
                resultId.Success = true;
                resultId.Data = takeId;
            }
            else
            {
                resultId.Success = false;
                resultId.Data = "Not faund get byid product";
            }
            return resultId;
        }

        public RepontResult Remove(int id)
        {
            var result = new RepontResult();
            var require = _context.Colors.FirstOrDefault(x => x.Id == id);
            if (require != null)
            {
                _context.Colors.Remove(require);
                _context.SaveChanges();
                result.Success = true;

            }
            else
            {
                result.Success = false;
                result.Message = " Not found is iđ";
            }
            return result;
        }

        public async Task<RepontResult> Update(ColorViewModel color)
        {
            var result = new RepontResult();
            var record = _context.Colors.FirstOrDefault(x => x.Id == color.Id);
            if (record != null)
            {
                record.Name = color.Name;
                _context.Colors.Update(record);
                await _context.SaveChangesAsync();
                result.Success = true;
                
            }
            else
            {
                result.Success = false;
                result.Message = " Not found is iđ";
            }
            return result;
        }
    }
}
