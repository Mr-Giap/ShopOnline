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
    public class SlideService : ISlideService
    {
        private readonly AppDBContext _context;
        private IMapper _mapper = AutoMapperConfig.RegisterMappings().CreateMapper();
        public SlideService(AppDBContext context)
        {
            this._context = context;
        }
        public Task<SlideViewModel> Add(SlideViewModel slide)
        {
            throw new NotImplementedException();
        }

        public Task<SlideViewModel> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public PageResult<SlideViewModel> GetAllPagging(string keyword, int pageSize, int pageIndex)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SlideViewModel> Update(SlideViewModel slide)
        {
            throw new NotImplementedException();
        }

        SlideViewModel ISlideService.Update(SlideViewModel slide)
        {
            throw new NotImplementedException();
        }
    }
}
