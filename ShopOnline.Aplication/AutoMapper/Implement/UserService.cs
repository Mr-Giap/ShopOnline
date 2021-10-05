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
    public class UserService : IUserService
    {
        private readonly AppDBContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole>   _roleManager        ;

        private IMapper _mapper = AutoMapperConfig.RegisterMappings().CreateMapper();
        public UserService(AppDBContext context,
            UserManager<AppUser> userManager,
            RoleManager<AppRole>  roleManager
            )
        {
            this._context = context;
            this._roleManager = roleManager;
            this._userManager = userManager;
        }
       /// <summary>
       /// tao tai khoan
       /// </summary>
       /// <param name="user">du lieu nguoi dung</param>
       /// <returns> du lieu nguoi dung</returns>
        public async Task<AppUserViewModel> Add(AppUserViewModel user)
        {
            //khoi tao user moi
            var newUser=new AppUser()
            {               
            Email = user.Email,
            UserName = user.UserName,
            FullName = user.FullName,
            Address = user.Address,
            Avatar = user.Avatar,
            status = Utils.Enum.Status.Active,
            PhoneNumber = user. PhoneNumber,
            DateCreated=DateTime.Now          
        };
            //add user
            var result = await _userManager.CreateAsync(newUser, user.PassWord);
            if (result.Succeeded && user.roles.Count > 0)
            {
                var appUser = await _userManager.FindByNameAsync(user.UserName);
                var lstRole = new List<string>();
                foreach (var item in user.roles)
                {
                    lstRole.Add(item.Name);
                }
                if (appUser != null)
                    await _userManager.AddToRolesAsync(appUser, lstRole);
                return _mapper.Map<AppUser, AppUserViewModel>(appUser);

            }
            return null;
        }

        public async  Task<AppUserViewModel> FindById(Guid id)
        {
            var userFind =await _context.appUsers.FindAsync(id);
            if (userFind != null)
            {
                return  _mapper.Map<AppUserViewModel>(userFind);
            }
            return null;
        }

        public PageResult<AppUserViewModel> GetAllPagging(string keyword, int pageSize, int pageIndex)
        {
            var users = _context.appUsers.ProjectTo<AppUserViewModel>(AutoMapperConfig.RegisterMappings());
            if (!string.IsNullOrEmpty(keyword))
            {
                users = users.Where(x => x.FullName.Contains(keyword) || x.PhoneNumber == (keyword) || x.Email == (keyword));
            }
            //tong so ban ghi
            int totalRow = users.Count();
            //lay user
            //skip:  bo qua
            //take: lay 
            users = users.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            var result = new PageResult<AppUserViewModel>()
            {
                Results = users.ToList(),
                CurrentPage = pageIndex,
                PageSize = pageSize,
                RowCount = totalRow
            };
            return result;
        }

        public void Remove(Guid id)
        {
            //FirstOrDefault : neu k co ban ghi=>
            //1 tra ve ban ghi  dau tien
            //2 return null
            //first :lay ban gi dau tien
            //var User = _context.appUsers.Where(x => x.Id == id).FirstOrDefault();
            var User = _context.appUsers.FirstOrDefault(x => x.Id == id);

            if (User != null)
            {
                _context.appUsers.Remove(User);
                _context.SaveChanges();
            }
             
        }

        public async Task<AppUserViewModel> Update(AppUserViewModel user)
        {
           var updateUser=_context.appUsers.FirstOrDefault(x => x.Id == user.Id);
            if (updateUser != null)
            {
                updateUser.FullName = user.FullName;
                updateUser.Address = user.Address;
                updateUser.Avatar = user.Avatar;
                updateUser.status = Utils.Enum.Status.Active;
                updateUser.PhoneNumber = user.PhoneNumber;
                updateUser.DateModifiled = DateTime.Now;
                var result = await _userManager.UpdateAsync(updateUser);
                return _mapper.Map<AppUserViewModel>(updateUser);
            }
            return null;
        }

      
    }
}
