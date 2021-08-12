using AutoMapper;
using AutoMapper.QueryableExtensions;
using ShopOnline.Aplication.AutoMapper;
using ShopOnline.Aplication.Interface.Admin;
using ShopOnline.Aplication.ViewModel.Admin;
using ShopOnline.Data.Entities;
using ShopOnline.DataEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Utilsss;

namespace ShopOnline.Aplication.Implement
{
    public class ProductService : IProductService
    {
        private readonly AppDBContext _context;    
        private IMapper _mapper = AutoMapperConfig.RegisterMappings().CreateMapper();

        public ProductService(AppDBContext context)
        {
            this._context = context;           
        }

        public async Task<GenericResult> Add(ProductViewModel product)
        {
            var result = new GenericResult();
            var newProduct = new Product()
            {
                Name = product.Name,
                Price = product.Price,
                PricPromotion = product.PricPromotion,
                Description = product.Description,
                Amount = product.Amount,
                SortDescription = product.SortDescription,
                SeoDescription = product.SeoDescription,
                SeoTitle = product.SeoTitle,
                SeoKeyWord = product.SeoKeyWord
            };
             await _context.products.AddAsync(newProduct);
            await _context.SaveChangesAsync();

            var productdb = _context.products.FirstOrDefault(x => x.Name == product.Name);
            result.Success = true;

            return result;
            //new product
            //reload

        }

        public async Task<GenericResult> FindById(int id)
        {
            var result = new GenericResult();
            var findProduct = await _context.products.FindAsync(id);
            if(findProduct!=null)
            {
                 _mapper.Map<ProductViewModel>(findProduct);
                result.Success = true;
            }
            else
            {
                result.Success = false;
                result.Message = "not found product";
            }
            return result;
        }

        public PageResult<ProductViewModel> GetAllPagging(string keyword, int pageSize, int pageIndex)
        {
            var products = _context.products.ProjectTo<ProductViewModel>(AutoMapperConfig.RegisterMappings());
            if (!string.IsNullOrEmpty(keyword))
            {
                products = products.Where(x => x.Name.Contains(keyword) || x.SeoDescription.Contains(keyword));
            }
            int totalRow = products.Count();
            products = products.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            var result = new PageResult<ProductViewModel>()
            {
                Results = products.ToList(),
                CurrentPage = pageIndex,
                PageSize = pageSize,
                RowCount = totalRow
            };
            return result;   
        }

        public GenericResult Remove(int id)
        {
            var result = new GenericResult();
            var product = _context.products.FirstOrDefault(x => x.Id == id);

            if (product != null)
            {
                _context.products.Remove(product);
                _context.SaveChanges();
            }
            else
            {
                result.Success = false;
                result.Message = "not found product";
            }
            return result;
        }

        public async Task<GenericResult> Update(ProductViewModel product)
        {
            var result = new GenericResult();
            var updateProduct = _context.products.FirstOrDefault(x => x.Name == product.Name);
            if (updateProduct!=null)
            {
                updateProduct.Name = product.Name;
                updateProduct.Price = product.Price;
                updateProduct.PricPromotion = product.PricPromotion;
                updateProduct.SeoDescription = product.SeoDescription;
                updateProduct.SeoKeyWord = product.SeoKeyWord;
                updateProduct.SeoTitle = product.SeoTitle;
                updateProduct.Amount = product.Amount;
               

                _context.products.Update(updateProduct);
                await _context.SaveChangesAsync();

                result.Success = true;
      
            }
            else
            {
                result.Success = false;
                result.Message = "not found product";   
            }
            return result;
        }
    }
}
