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
    public class CategoryServiceClient : BaseService, ICategoryServiceClient
    {

        private readonly AppDbContext _context;
        // Nếu mà Add 1 service ở đây thì trong startup phải tiêm AddScoped cho nó. vd : giờ thêm categoryService thì statup cũng phải có.
        private IMapper _mapper = AutoMapperConfig.RegisterMappings().CreateMapper();
        public CategoryServiceClient(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<CategoryViewModelClient>> GetAll()
        {
            List<CategoryViewModelClient> results = new List<CategoryViewModelClient>();

            using (var response = await httpClient.GetAsync("api/category"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                results = JsonConvert.DeserializeObject<List<CategoryViewModelClient>>(apiResponse);
            }
            return results;
        }

        public PageResult<CategoryViewModelClient> GetAllPaggingClient(string keyword, int page, int pageSize)
        {
            // Lấy ra product
            var category = _context.Categories.ProjectTo<CategoryViewModelClient>(AutoMapperConfig.RegisterMappings());
            if (!string.IsNullOrEmpty(keyword))
            {
                category = category.Where(x => x.Name.Contains(keyword) || x.SeoDescription.Contains(keyword) || x.SeoKeyWord.Contains(keyword) || x.SeoTitle.Contains(keyword));
            }
            int totalRow = category.Count();
            category = category.Skip((page - 1) * pageSize)
                .Take(pageSize);
            var results = new PageResult<CategoryViewModelClient>()
            {
                Results = category.ToList(),
                CurrentPage = page, // số page hien tai
                RowCount = totalRow,
                PageSize = pageSize
            };
            return results;
        }

        public async Task<RepontResult> GetById(int id)
        {
            var resultId = new RepontResult();
            var takenId = await _context.Categories.FindAsync(id);
            if (takenId != null)
            {
                resultId.Success = true;
                resultId.Data = takenId;
            }
            else
            {
                resultId.Success = false;
                resultId.Data = "Not faund get byid category";
            }
            return resultId;
        }
    }
}
