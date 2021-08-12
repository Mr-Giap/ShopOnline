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
    public class ColorService : IColorService
    {
        private readonly AppDBContext _context;
        private IMapper _mapper = AutoMapperConfig.RegisterMappings().CreateMapper();
        public ColorService(AppDBContext context)
        {
            this._context = context;
        }
        public Task<ColorViewModel> Add(ColorViewModel color)
        {
            throw new NotImplementedException();
        }

        public Task<ColorViewModel> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public PageResult<ColorViewModel> GetAllPagging(string keyword, int pageSize, int pageIndex)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ColorViewModel> Update(ColorViewModel color)
        {
            throw new NotImplementedException();
        }

        ColorViewModel IColorService.Update(ColorViewModel color)
        {
            throw new NotImplementedException();
        }
    }
}
