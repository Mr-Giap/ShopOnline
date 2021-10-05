using Microsoft.AspNetCore.Identity;
using ShopOnline.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Enum;

namespace ShopOnline.DataEF
{
    public class DbInitializer

    {
        private readonly AppDBContext _context;
        private UserManager<AppUser> _userManager;
        private RoleManager<AppRole> _roleManager;
        public DbInitializer(AppDBContext context, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            this._context = context;
            this._userManager = userManager;
            this._roleManager = roleManager;
        }
        //theem data khi tao bang
        public async Task Seed()
        {
            try
            {
                // add role
                if (!_roleManager.Roles.Any())
                {
                    await _roleManager.CreateAsync(new AppRole()
                    {
                        Name = "Admin",
                        NormalizedName = "Admin"
                    });
                    await _roleManager.CreateAsync(new AppRole()
                    {
                        Name = "Staff",
                        NormalizedName = "Staff"
                    });
                    await _roleManager.CreateAsync(new AppRole()
                    {
                        Name = "Customer",
                        NormalizedName = "Customer"
                    });
                }
                // add user
                if (!_userManager.Users.Any())
                {
                    await _userManager.CreateAsync(new AppUser()
                    {
                        UserName = "admin",
                        FullName = "Administrator",
                        Email = "admin@gmail.com",
                        DateCreated = DateTime.Now,
                        DateModifiled = DateTime.Now,
                        status = Status.Active
                    }, "123456aA@");
                    var user = await _userManager.FindByNameAsync("admin");
                    await _userManager.AddToRoleAsync(user, "Admin");
                }
                // add categories
                if (!_context.categories.Any())
                {
                    await _context.categories.AddAsync(new Category()
                    {
                        Name = "Điện thoại",
                        IsShow = true,
                        NameAcsii="",
                        DateCreated=DateTime.Now,
                        DateModifiled=DateTime.Now

                    });                
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }

        }

    }
}