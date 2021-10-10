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
    public class TagService : ITagService
    {
        private readonly AppDbContext _context;
        private IMapper _maper = AutoMapperConfig.RegisterMappings().CreateMapper();

        public TagService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<RepontResult> Add(TagViewModel tag)
        {
            var result = new RepontResult();
            var newTag = new Tag()
            {
                Name = tag.Name
            };
            _context.Tags.Add(newTag);
            await _context.SaveChangesAsync();
            result.Success = true;
            return result;
        }

        public PageResult<TagViewModel> GetAllPagging(string keyword, int page, int pageSize)
        {
            var tag = _context.Tags.ProjectTo<TagViewModel>(AutoMapperConfig.RegisterMappings());
            if (!string.IsNullOrEmpty(keyword))
            {
                tag = tag.Where(x => x.Name.Contains(keyword));
            }
            int totalRow = tag.Count();
            tag = tag.Skip((page - 1) * pageSize)
                .Take(pageSize);
            var result = new PageResult<TagViewModel>()
            {
                Results = tag.ToList(),
                CurrentPage = page, // page hien tai
                RowCount = totalRow ,
                PageSize = pageSize
            };
            return result;
        }

        public async Task<TagViewModel> GetById(int id)
        {
            var takeId = await _context.Tags.FindAsync(id);
            if (takeId != null)
            {
                return _maper.Map<Tag, TagViewModel>(takeId);

            }
            return null;
        }

        public RepontResult Remove(int id)
        {
            var result = new RepontResult();
            var record = _context.Tags.FirstOrDefault(x => x.Id == id);
            if (record != null)
            {
                _context.Tags.Remove(record);
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

        public async Task<RepontResult> Update(TagViewModel tag)
        {
            var result = new RepontResult();
            var record = _context.Tags.FirstOrDefault(x => x.Id == tag.Id);
            if (record != null)
            {
                record.Name = tag.Name;
                _context.Tags.Update(record);
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
