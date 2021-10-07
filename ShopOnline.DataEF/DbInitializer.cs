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
        
        private readonly AppDbContext _context;
        private UserManager<AppUser> _userManager; //dùng implement(Tiêm phụ phuộc) vì đều đi qua UserManager và RoleManager
        private RoleManager<AppRole> _roleManager;
        public DbInitializer(AppDbContext context, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            this._context = context;
            this._userManager = userManager;
            this._roleManager = roleManager;
        }
        /// <summary>
        /// Gọi là seed data ... Để khởi tạo và add các  dataadmin đầu vào khi mình khởi tạo database
        /// Dùng Roles và Users
        /// </summary>
        /// <returns></returns>
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
                        Status = Status.Active
                    }, "123456aA@");
                    var user = await _userManager.FindByNameAsync("admin");
                    await _userManager.AddToRoleAsync(user, "Admin");
                }

                //add product
                if (!_context.Products.Any())
                {
                    var product = new Product()
                    {
                        Name = "Sp1"
                    };
                    await _context.Products.AddAsync(product);
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }

        }
    }
}
