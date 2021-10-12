
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
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        // thêm 2 thằng để sử dụng  Identity
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        // truyền auto mapper vào
        private IMapper _mapper = AutoMapperConfig.RegisterMappings().CreateMapper();
        public UserService(AppDbContext contex,UserManager<AppUser> userManager,RoleManager<AppRole> roleManager)
        {
            this._context = contex;
            this._userManager = userManager;
            this._roleManager = roleManager;

        }
        /// <summary>
        ///  Khởi tạo user để ánh xạ dữ liệu ->  lấy các trường mình muốn
        /// </summary>
        /// <param name="user">Đối tượng user</param>
        /// <returns>Dữ liệu của user</returns>
        public async Task<AppUserViewModel> Add(AppUserViewModel user)
        {
            // Khởi tạo đối tượng user. truyền đầy đủ các trường muốn lấy.
            var newUser = new AppUser()
            {
                UserName = user.UserName,
                Avatar = user.Avatar,
                Email = user.Email,
                FullName = user.FullName,
                DateCreated = DateTime.Now,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                Status = Utils.Enum.Status.Active
            };
            var result = await _userManager.CreateAsync(newUser, user.PassWord);
            if (result.Succeeded && user.Roles.Count > 0)
            {
                var appUser = await _userManager.FindByNameAsync(user.UserName);
                var lstRole = new List<string>();
                foreach (var item in user.Roles)
                {
                    lstRole.Add(item.Name);
                }
                if (appUser != null)
                    await _userManager.AddToRolesAsync(appUser, lstRole);
                // mapper chuyển từ thằng AppUser sang thằng AppUserViewModel 
                // vì mình đang gọi tới AppUserViewModel
                return _mapper.Map<AppUser, AppUserViewModel>(appUser);

            }
            return null;
        }

        public PageResult<AppUserViewModel> GetAllPagging(string keyword, int page, int pageSize)
        {
            // get all user
            var users = _context.AppUsers.ProjectTo<AppUserViewModel>(AutoMapperConfig.RegisterMappings());
            // kiểm tra keyword có null k
            if (!string.IsNullOrEmpty(keyword))
            {
                users = users.Where(x => x.FullName.Contains(keyword) || x.PhoneNumber.Contains(keyword) || x.Email.Contains(keyword));
            }
            // tổng số bản ghi
            int totalRow = users.Count();
            // Lấy phân trang :  Skin () là bỏ qua bao nhiêu bản ghi (pz =10 thì lấy đc ps =1 -> qua 40 bản ghi)
            // Take là lấy số bản ghi 
            // trong sql :"SELECT * FROM customer LIMIT 10 OFFSET 20
            users = users.Skip((page - 1) * pageSize)
                .Take(pageSize);
            var results = new PageResult<AppUserViewModel>()
            {
                Results = users.ToList(),
                CurrentPage = page, // page hien tai
                RowCount = totalRow,
                PageSize = pageSize
            };
            return results;
        }


        public async Task<AppUserViewModel> GetById(Guid id)
        {
            var getIdUser = await _context.AppUsers.FindAsync(id);
            if (getIdUser != null)
            {
                return _mapper.Map<AppUser, AppUserViewModel>(getIdUser);
            }
            return null;
        }

        public void Remove(Guid id)
        {
            var result = _context.AppUsers.FirstOrDefault(x => x.Id == id);
            if (result != null)
            {
                _context.AppUsers.Remove(result);
                _context.SaveChanges();

            }
        }

        public async Task<AppUserViewModel> Update(AppUserViewModel user)
        {
            var updateUser =  _context.AppUsers.FirstOrDefault(x => x.Id == user.Id);
            if (updateUser != null)
            {
                updateUser.Avatar = user.Avatar;
                updateUser.FullName = user.FullName;
                updateUser.DateCreated = DateTime.Now;
                updateUser.PhoneNumber = user.PhoneNumber;
                updateUser.Address = user.Address;
                updateUser.Status = Utils.Enum.Status.Active;
                // khi update thì nó sinh ra 1 stem của user nên phải dùng _userManager để cập nhật
                var resultupdate = await _userManager.UpdateAsync(updateUser);

                return _mapper.Map<AppUserViewModel>(resultupdate);
            }
            else
            {
                return null;
            }
           
        }
       
    }
}
