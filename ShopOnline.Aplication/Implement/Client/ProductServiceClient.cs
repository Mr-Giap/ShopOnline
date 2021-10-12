using AutoMapper;
using AutoMapper.QueryableExtensions;
using Newtonsoft.Json;
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
    public class ProductServiceClient : BaseService, IProductServiceClient
    {
        private readonly AppDbContext _context;
        // Nếu mà Add 1 service ở đây thì trong startup phải tiêm AddScoped cho nó. vd : giờ thêm categoryService thì statup cũng phải có.
        private IMapper _mapper = AutoMapperConfig.RegisterMappings().CreateMapper();
        public ProductServiceClient(AppDbContext context)
        {
            _context = context;
        }

        public PageResult<ProductViewModelClient> GetAllPaggingClient(string keyword, int page, int pageSize)
        {
            // Lấy ra product
            var product = _context.Products.ProjectTo<ProductViewModelClient>(AutoMapperConfig.RegisterMappings());
            if (!string.IsNullOrEmpty(keyword))
            {
                product = product.Where(x => x.Name.Contains(keyword) || x.Description.Contains(keyword) || x.SeoDescription.Contains(keyword) || x.SeoKeyWord.Contains(keyword) || x.SeoTitle.Contains(keyword));
            }
            int totalRow = product.Count();
            product = product.Skip((page - 1) * pageSize)
                .Take(pageSize);
            var results = new PageResult<ProductViewModelClient>()
            {
                Results = product.ToList(),
                CurrentPage = page, // số page hien tai
                RowCount = totalRow,
                PageSize = pageSize
            };
            return results;
        }

        public async Task<RepontResult> GetById(int id)
        {
            var resultId = new RepontResult();
            var takenId = await _context.Products.FindAsync(id);
            if (takenId != null)
            {
                resultId.Success = true;
                resultId.Data = takenId;
            }
            else
            {
                resultId.Success = false;
                resultId.Data = "Not faund get byid product";
            }
            return resultId;
        }

        public async Task<List<ProductViewModelClient>> GetAll()
        {
            List<ProductViewModelClient> results = new List<ProductViewModelClient>();

            using (var response = await httpClient.GetAsync("api/product"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                results = JsonConvert.DeserializeObject<List<ProductViewModelClient>>(apiResponse);
            }
            return results;
        }
    }
}
