using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
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
    public class RoleService : IRoleService
    {
        private readonly AppDBContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private IMapper _mapper = AutoMapperConfig.RegisterMappings().CreateMapper();
        
        public RoleService(AppDBContext context,
            UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager)
        {
            this._context = context;
            this._roleManager = roleManager;
            this._userManager = userManager;
        }
        public async Task<AppRoleViewModel> Add(AppRoleViewModel role)
        {
            var newRole = new AppRole()
            {
                Name=role.Name,
                DateCreated = DateTime.Now,
            };
            var result = await _roleManager.CreateAsync(newRole);
            if (result.Succeeded)
            {
                var appRole = await _roleManager.FindByIdAsync(role.Name);
                return _mapper.Map<AppRole, AppRoleViewModel>(appRole);
            }
            return null;
        }

        public async Task<AppRoleViewModel> FindById(Guid id)
        {
            var roleFind = await _context.appRoles.FindAsync(id);
            if (roleFind != null)
            {
                return _mapper.Map<AppRoleViewModel>(roleFind);
            }
            return null;
        }

        public PageResult<AppRoleViewModel> GetAllPagging(string keyword, int pageSize, int pageIndex)
        {
            var roles = _context.Roles.ProjectTo<AppRoleViewModel>(AutoMapperConfig.RegisterMappings());
            if (!string.IsNullOrEmpty(keyword))
            {
                roles = roles.Where(x => x.Name.Contains(keyword));
            }
            int totalRow = roles.Count();

            roles = roles.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            var result = new PageResult<AppRoleViewModel>()
            {
                Results = roles.ToList(),
                CurrentPage = pageIndex,
                PageSize = pageSize,
                RowCount = totalRow
            };
            return result;
        }

        public void Remove(Guid id)
        {
            var Role = _context.appRoles.FirstOrDefault(x => x.Id == id);
            if (Role != null)
            {
                _context.appRoles.Remove(Role);
                _context.SaveChanges();
            }
        }

        public async Task<AppRoleViewModel> Update(AppRoleViewModel role)
        {
            var updateRole = _context.appRoles.FirstOrDefault(x => x.Id == role.Id);
            if (updateRole!=null)
            {
                updateRole.Name = role.Name;
                updateRole.DateModifiled = DateTime.Now;
                var result = await _roleManager.UpdateAsync(updateRole);
                return _mapper.Map<AppRoleViewModel>(updateRole);
            }
            return null;
        }
    }
}
