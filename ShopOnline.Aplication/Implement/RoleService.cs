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
    public class RoleService : IRoleService
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppRole> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private IMapper _mapper = AutoMapperConfig.RegisterMappings().CreateMapper();
        public RoleService(AppDbContext context, UserManager<AppRole> userManager, RoleManager<AppRole> roleManager)
        {
            this._context = context;
            this._userManager = userManager;
            this._roleManager = roleManager;

        }

        public async Task<AppRoleViewModel> Add(AppRoleViewModel role)
        {
            var newRole = new AppRole()
            {
                Id = role.Id,
                Name = role.Name,
                DateCreated = DateTime.Now
            };
            var result = await _roleManager.CreateAsync(newRole);
            if (result.Succeeded)
            {
                var appRole = await _roleManager.FindByIdAsync(role.Name);
                return _mapper.Map<AppRole, AppRoleViewModel>(appRole);
            }
            return null;
        }

        public PageResult<AppRoleViewModel> GetAllPagging(string keyword, int pageSize, int pageIndex)
        {
            // get all user
            var role = _context.AppRoles.ProjectTo<AppRoleViewModel>(AutoMapperConfig.RegisterMappings());
            // kiểm tra keyword có null k
            if (!string.IsNullOrEmpty(keyword))
            {
                role = role.Where(x => x.Name.Contains(keyword));
            }
            // tổng số bản ghi
            int totalRow = role.Count();
            role = role.Skip((pageSize - 1) * pageIndex)
                .Take(pageSize);
            var results = new PageResult<AppRoleViewModel>
            {
                Results = role.ToList(),
                CurrentPage = pageIndex, // page hien tai
                PageSize = pageSize,
                RowCount = totalRow
            };
            return results;
        }

        public async Task<AppRoleViewModel> GetById(Guid id)
        {
            var getIdRole =await  _context.AppRoles.FindAsync(id);
            if (getIdRole != null)
            {
                return _mapper.Map<AppRole, AppRoleViewModel>(getIdRole);
            }
            return null;
        }
        public void Remove(Guid id)
        {
            var removeRole = _context.AppRoles.FirstOrDefault(x => x.Id == id);
            if (removeRole != null)
            {
                 _context.AppRoles.Remove(removeRole);
                _context.SaveChanges();
            }
        }

        public async Task<AppRoleViewModel> Update(AppRoleViewModel role)
        {
            var updateRole = _context.AppRoles.FirstOrDefault(x => x.Id == role.Id);
            if (updateRole != null)
            {
                updateRole.Id = role.Id;
                updateRole.Name = role.Name;
                updateRole.DateCreated = DateTime.Now;
                //updateRole.DateModifiled = DateTime.Now;
                var result = await _roleManager.UpdateAsync(updateRole);
                return _mapper.Map<AppRoleViewModel>(updateRole);
            }
            else 
            {  
                 return null;
            }
        }
    }
}
