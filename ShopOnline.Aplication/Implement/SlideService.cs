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
    public class SlideService : ISlideService
    {
        private readonly AppDbContext _context;
        private IMapper _maper = AutoMapperConfig.RegisterMappings().CreateMapper();
        public SlideService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<RepontResult> Add(SlideViewModel slide)
        {
            var results = new RepontResult();
            var newSlide = new Slide()
            {
                IsShow = slide.IsShow
            };
            _context.Slides.Add(newSlide);
            await _context.SaveChangesAsync();
            results.Success = true;
            return results;
        }

        public PageResult<SlideViewModel> GetAllPagging(string keyword, int pageSize, int pageIndex)
        {
            var slide = _context.Slides.ProjectTo<SlideViewModel>(AutoMapperConfig.RegisterMappings());
            int totalRow = slide.Count();
            slide = slide.Skip((pageSize - 1) * pageIndex)
                .Take(pageSize);
            var result = new PageResult<SlideViewModel>()
            {
                Results = slide.ToList(),
                CurrentPage = pageIndex, // page hien tai
                PageSize = pageSize,
                RowCount = totalRow
            };
            return result;
        }

        public async Task<SlideViewModel> GetById(int id)
        {
            var takeId = await _context.Slides.FindAsync(id);
            if (takeId != null)
            {
                return _maper.Map<Slide, SlideViewModel>(takeId);
            }
            return null;
        }

        public RepontResult Remove(int id)
        {
            var result = new RepontResult();
            var record = _context.Slides.FirstOrDefault(x => x.Id == id);
            if (record != null)
            {
                _context.Slides.Remove(record);
                _context.SaveChanges();
                result.Success = true;
            }
            else
            {
                result.Success = false;
                result.Message = "Not found is id slide";
            }
            return result;
        }

        public async Task<RepontResult> Update(SlideViewModel slide)
        {
            var result = new RepontResult();
            var require = _context.Slides.FirstOrDefault(x => x.Id == slide.Id);
            if (require != null)
            {
                require.Id = slide.Id;
                require.IsShow = slide.IsShow;
                 _context.Slides.Update(require);
                await _context.SaveChangesAsync();
                result.Success = true;
            }
            else
            {
                result.Success = false;
                result.Message = "Not found id skide";
            }
            return result;
        }
    }
}
