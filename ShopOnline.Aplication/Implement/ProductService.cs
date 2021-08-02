using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
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
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        // Nếu mà Add 1 service ở đây thì trong startup phải tiêm AddScoped cho nó. vd : giờ thêm categoryService thì statup cũng phải có.
        private IMapper _mapper = AutoMapperConfig.RegisterMappings().CreateMapper();
        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<RepontResult> Add(ProductViewModel product)
        {
            var resultMess = new RepontResult();
            var newProduct = new Product()
            {
                Name = product.Name,
                Price = product.Price,
                PricePromotion = product.PricePromotion,
                Description = product.Description,
                Amount = product.Amount,
                IsShow = product.IsShow,
                DisplayOrder = product.DisplayOrder,
                SeoDescription = product.SeoDescription,
                SeoTitle = product.SeoTitle,
                SeoKeyWord = product.SeoKeyWord
            };
            await  _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();


            resultMess.Success = true;
            return resultMess;
            // Nếu là kiểu Task<ProductViewModel> thì phải chuyển từ kiểu Product sang kiểu ProductViewModel thì ta dung mapping
            /*
              if(resultMess != null)
                    return _maper.Map<Product,ProductViewModel>(resultMess);
             */ 
        }

        public PageResult<ProductViewModel> GetAllPagging(string keyword, int pageSize, int pageIndex)
        {
            // Lấy ra product
            var product  = _context.Products.ProjectTo<ProductViewModel>(AutoMapperConfig.RegisterMappings());
            if (!string.IsNullOrEmpty(keyword))
            {
                product = product.Where(x => x.Name.Contains(keyword) || x.NameAscii.Contains(keyword) || x.Description.Contains(keyword) || x.SeoDescription.Contains(keyword) || x.SeoKeyWord.Contains(keyword) || x.SeoTitle.Contains(keyword));
            }
            int totalRow = product.Count();
            product = product.Skip((pageSize - 1) * pageIndex)
                .Take(pageSize);
            var results = new PageResult<ProductViewModel>()
            {
                Results = product.ToList(),
                CurrentPage = pageIndex, // page hien tai
                PageSize = pageSize,
                RowCount = totalRow
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
               // return _mapper.Map<ProductViewModel>(takenId);
            }
            else
            {
                resultId.Success = false;
                resultId.Data = "Not faund get byid product";
            }
            return resultId;
        }

        public RepontResult Remove(int id)
        {
            var resultId = new RepontResult();
            var record = _context.Products.FirstOrDefault(x => x.Id == id);
            if (record != null)
            {
                 _context.Products.Remove(record);
                _context.SaveChanges();
                resultId.Success = true;
            }
            else
            {
                resultId.Success = false;
                resultId.Message = "Not Found Product Id Remove";
            }
            return resultId;
        }

        public async Task<RepontResult> Update(ProductViewModel product)
        {
            var resultUpdate = new RepontResult();
            var record = _context.Products.FirstOrDefault(x => x.Id == product.Id);
            if (record != null)
            {
                record.Name = product.Name;
                record.Price = product.Price;
                record.Amount = product.Amount;
                record.IsShow = product.IsShow;
                record.PricePromotion = product.PricePromotion;
                record.Description = product.Description;
                record.DisplayOrder = product.DisplayOrder;
                record.SeoDescription = product.SeoDescription;
                record.SeoTitle = product.SeoTitle;
                record.SeoKeyWord = product.SeoKeyWord;
                _context.Products.Update(record);
                await _context.SaveChangesAsync();
                resultUpdate.Success = true;
               // return _mapper.Map<Product, ProductViewModel>(record);
            }
            else
            {
                resultUpdate.Success = false;
                resultUpdate.Message = "Not found is a update Product";
            }
            return resultUpdate;
        }
    }
}
