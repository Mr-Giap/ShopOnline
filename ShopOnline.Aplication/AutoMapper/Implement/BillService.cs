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
    public class BillService : IBillService
    {
        private readonly AppDBContext _context;
        private IMapper _mapper = AutoMapperConfig.RegisterMappings().CreateMapper();
        public BillService(AppDBContext context)
        {
            this._context = context;
        }

        public async Task<GenericResult> Add(BillViewModel bill)
        {
            var result = new GenericResult();
            var newBill = new Bill()
            {
                UserId = bill.UserId,
                Status = bill.Status,
                paymentMethod = bill.paymentMethod
            };
            await _context.bills.AddAsync(newBill);
            await _context.SaveChangesAsync();

            var billdb = _context.bills.FirstOrDefault(x => x.UserId == bill.UserId);
            result.Success = true;

            return result;
        }

        public async Task<GenericResult> FindById(int id)
        {
            var result = new GenericResult();
            var findBill = await _context.bills.FindAsync(id);
            if (findBill != null)
            {
                _mapper.Map<ProductViewModel>(findBill);
                result.Success = true;
            }
            else
            {
                result.Success = false;
                result.Message = "not found Bill";
            }
            return result;
        }

        public PageResult<BillViewModel> GetAllPagging(string keyword, int pageSize, int pageIndex)
        {
            var bills = _context.bills.ProjectTo<BillViewModel>(AutoMapperConfig.RegisterMappings());
            if (!string.IsNullOrEmpty(keyword))
            {
                bills = bills.Where(x => x.UserId.ToString().Contains(keyword));
            }
            int totalRow = bills.Count();
            bills = bills.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            var result = new PageResult<BillViewModel>()
            {
                Results = bills.ToList(),
                CurrentPage = pageIndex,
                PageSize = pageSize,
                RowCount = totalRow
            };
            return result;
        }

        public GenericResult Remove(int id)
        {

            var result = new GenericResult();
            var bill = _context.bills.FirstOrDefault(x => x.Id == id);

            if (bill != null)
            {
                _context.bills.Remove(bill);
                _context.SaveChanges();
            }
            else
            {
                result.Success = false;
                result.Message = "not found bill";
            }
            return result;
        }

        public Task<GenericResult> Update(BillViewModel bill)
        {
            throw new NotImplementedException();
        }

        //public async Task<GenericResult> Update(BillViewModel bill)
        //{
        //var result = new GenericResult();
        //var updateProduct = _context.products.FirstOrDefault(x => x.Name == product.Name);
        //if (updateProduct != null)
        //{
        //    updateProduct.Name = product.Name;
        //    updateProduct.Price = product.Price;
        //    updateProduct.PricPromotion = product.PricPromotion;
        //    updateProduct.SeoDescription = product.SeoDescription;
        //    updateProduct.SeoKeyWord = product.SeoKeyWord;
        //    updateProduct.SeoTitle = product.SeoTitle;
        //    updateProduct.Amount = product.Amount;


        //    _context.products.Update(updateProduct);
        //    await _context.SaveChangesAsync();

        //    result.Success = true;

        //}
        //else
        //{
        //    result.Success = false;
        //    result.Message = "not found product";
        //}
        //return result;
        //}
    }
}
