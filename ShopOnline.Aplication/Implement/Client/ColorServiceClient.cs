using AutoMapper;
using AutoMapper.QueryableExtensions;
using ShopOnline.Aplication.Automapper;
using ShopOnline.Aplication.Interface.Client;
using ShopOnline.Aplication.ViewModel.Client;
using ShopOnline.DataEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Dtos;

namespace ShopOnline.Aplication.Implement.Client
{
    public class ColorServiceClient : BaseService, IColorServiceClient
    {
        private readonly AppDbContext _context;
        // Nếu mà Add 1 service ở đây thì trong startup phải tiêm AddScoped cho nó. vd : giờ thêm categoryService thì statup cũng phải có.
        private IMapper _mapper = AutoMapperConfig.RegisterMappings().CreateMapper();
        public ColorServiceClient(AppDbContext context)
        {
            _context = context;
        }
        public PageResult<ColorViewModelClient> GetAllPaggingClient(string keyword, int page, int pageSize)
        {
            var color = _context.Products.ProjectTo<ColorViewModelClient>(AutoMapperConfig.RegisterMappings());
            if (!string.IsNullOrEmpty(keyword))
            {
                color = color.Where(x => x.Name.Contains(keyword));
            }
            int totalRow = color.Count();
            color = color.Skip((page - 1) * pageSize)
                .Take(pageSize);
            var results = new PageResult<ColorViewModelClient>()
            {
                Results = color.ToList(),
                CurrentPage = page, // số page hien tai
                RowCount = totalRow,
                PageSize = pageSize
            };
            return results;
        }

        public async Task<RepontResult> GetById(int id)
        {
            var resultId = new RepontResult();
            var takenId = await _context.Colors.FindAsync(id);
            if (takenId != null)
            {
                resultId.Success = true;
                resultId.Data = takenId;
            }
            else
            {
                resultId.Success = false;
                resultId.Data = "Not faund get byid color";
            }
            return resultId;
        }
    }
}
