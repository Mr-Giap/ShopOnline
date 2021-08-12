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
    public class TagService : ITagService
    {
        private readonly AppDBContext _context;
        private IMapper _mapper = AutoMapperConfig.RegisterMappings().CreateMapper();
        public TagService(AppDBContext context)
        {
            this._context = context;
        }
        public async Task<TagViewModel> Add(TagViewModel tag)
        {
            var tagNew = new Tag()
            {
                Name = tag.Name,             
                DateCreated = DateTime.Now
            };
            var result = await _context.tags.AddAsync(tagNew);
            var tagRT = _context.tags.FirstOrDefault(x => x.Name == tag.Name);
            return _mapper.Map<Tag, TagViewModel>(tagRT);           
        }

        public async Task<TagViewModel> FindById(int id)
        {
            var findTag = await _context.tags.FindAsync(id);
            if (findTag != null)
            {
                return _mapper.Map<TagViewModel>(findTag);
            }
            return null;
        }

        public PageResult<TagViewModel> GetAllPagging(string keyword, int pageSize, int pageIndex)
        {
            var tags = _context.tags.ProjectTo<TagViewModel>(AutoMapperConfig.RegisterMappings());
            if (!string.IsNullOrEmpty(keyword))
            {
                tags = tags.Where(x => x.Name.Contains(keyword));
            }
            int totalRow = tags.Count();
            tags = tags.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            var result = new PageResult<TagViewModel>()
            {
                Results = tags.ToList(),
                CurrentPage = pageIndex,
                PageSize = pageSize,
                RowCount = totalRow
            };
            return result;
        }

        public void Remove(int id)
        {
            var tagDelete = _context.tags.FirstOrDefault(x => x.Id == id);

            if (tagDelete != null)
            {
                _context.tags.Remove(tagDelete);
                _context.SaveChanges();
            }
        }

        public TagViewModel Update(TagViewModel tag)
        {
            var updateTag = _context.products.FirstOrDefault(x => x.Name == tag.Name);
            if (updateTag != null)
            {
                updateTag.Name = tag.Name;

                updateTag.DateModifiled = DateTime.Now;

                var result = _context.products.Update(updateTag);

                return _mapper.Map<TagViewModel>(updateTag);

            }
            return null;
        }
    }
}
