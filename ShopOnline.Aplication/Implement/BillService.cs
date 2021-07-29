using AutoMapper;
using AutoMapper.QueryableExtensions;
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
    public class BillService : IBillService
    {
        private readonly AppDbContext _context;
        private IMapper _maper = AutoMapperConfig.RegisterMappings().CreateMapper();

        public BillService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<RepontResult> Add(BillViewModel bil)
        {
            var resultAdd = new RepontResult();
            var newCategory = new Bill()
            {
                UserId = bil.UserId,
                Status = bil.Status,
                PaymentsMethod = bil.PaymentsMethod

            };
            _context.Bills.Add(newCategory);
            await _context.SaveChangesAsync();
            resultAdd.Success = true;
            return resultAdd;
        }

        public PageResult<BillViewModel> GetAllPagging(string keyword, int pageSize, int pageIndex)
        {
            var bill = _context.Bills.ProjectTo<BillViewModel>(AutoMapperConfig.RegisterMappings());
            int totalRow = bill.Count();
            bill = bill.Skip((pageSize - 1) * pageIndex)
                .Take(pageSize);
            var result = new PageResult<BillViewModel>()
            {
                Results = bill.ToList(),
                CurrentPage = pageIndex, // page hien tai
                PageSize = pageSize,
                RowCount = totalRow
            };
            return result;
        }

        public async Task<BillViewModel> GetById(int id)
        {
            var takeId = await _context.Bills.FindAsync(id);
            if (takeId != null)
            {
                return _maper.Map<Bill, BillViewModel>(takeId);
            }
            return null;
        }

        public RepontResult Remove(int id)
        {
            var result = new RepontResult();
            var record = _context.Bills.FirstOrDefault(x => x.Id == id);
            if (record != null)
            {
                _context.Bills.Remove(record);
                _context.SaveChanges();
                result.Success = true;
            }
            else
            {
                result.Success = false;
                result.Message = "Not Found id is category";
            }
            return result;
        }

        public async Task<RepontResult> Update(BillViewModel bil)
        {
            var resultUpdate = new RepontResult();
            var record = _context.Bills.FirstOrDefault(x => x.Id == bil.Id);
            if (record != null)
            {
                record.UserId = bil.UserId;
                record.Status = bil.Status; 
                record.PaymentsMethod = bil.PaymentsMethod;
              
                _context.Bills.Update(record);
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
