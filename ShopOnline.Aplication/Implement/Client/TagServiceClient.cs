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
    public class TagServiceClient : BaseService, ITagServiceClient
    {
        private readonly AppDbContext _context;
        private IMapper _mapper = AutoMapperConfig.RegisterMappings().CreateMapper();
        public TagServiceClient(AppDbContext context)
        {
            _context = context;
        }
        public PageResult<TagViewModelClient> GetAllPaggingClient(string keyword, int page, int pageSize)
        {
            // Lấy ra product
            var tags = _context.Products.ProjectTo<TagViewModelClient>(AutoMapperConfig.RegisterMappings());
            if (!string.IsNullOrEmpty(keyword))
            {
                tags = tags.Where(x => x.Name.Contains(keyword));
            }
            int totalRow = tags.Count();
            tags = tags.Skip((page - 1) * pageSize)
                .Take(pageSize);
            var results = new PageResult<TagViewModelClient>()
            {
                Results = tags.ToList(),
                CurrentPage = page, // số page hien tai
                RowCount = totalRow,
                PageSize = pageSize
            };
            return results;
        }
    }
}
