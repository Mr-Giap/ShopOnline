using AutoMapper;
using ShopOnline.Aplication.ViewModel.Admin;
using ShopOnline.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Aplication.AutoMapper
{
   public class ViewModelToDomainMappingProfile:Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<AppUserViewModel, AppUser>()
            .ConstructUsing(c => new AppUser(c.Id, c.Email, c.UserName, c.PhoneNumber,
            c.FullName, c.Address, c.Avatar, c.status));
        }
    }
}
