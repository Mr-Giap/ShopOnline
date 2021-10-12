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
    public class BillServiceClient : BaseService, IBillServiceClient
    {
        private readonly AppDbContext _context;
        private IMapper _mapper = AutoMapperConfig.RegisterMappings().CreateMapper();
        public BillServiceClient(AppDbContext context)
        {
            _context = context;
        }
        public PageResult<BillViewModelClient> GetAllPaggingClient(string keyword, int page, int pageSize)
        {
            // Lấy ra product
            var bill = _context.Bills.ProjectTo<BillViewModelClient>(AutoMapperConfig.RegisterMappings());
            int totalRow = bill.Count();
            bill = bill.Skip((page - 1) * pageSize)
                .Take(pageSize);
            var results = new PageResult<BillViewModelClient>()
            {
                Results = bill.ToList(),
                CurrentPage = page, // số page hien tai
                RowCount = totalRow,
                PageSize = pageSize
            };
            return results;
        }
    }
}
