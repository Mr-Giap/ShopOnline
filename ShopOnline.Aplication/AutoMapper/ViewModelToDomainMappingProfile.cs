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
            c.FullName, c.Address, c.Avatar, c.status,c.DateCreated,c.DateModifiled));

            CreateMap<AppRoleViewModel, AppRole>()
           .ConstructUsing(c => new AppRole(c.Id, c.Name ,c.DateCreated,c.DateModifiled));


            CreateMap<ProductViewModel, Product>()
          .ConstructUsing(c => new Product(c.Id,c.Name,c.NameAscii, c.Price, c.PricPromotion, c.Description, c.Amount, c.SortDescription, c.SeoDescription, c.SeoTitle, c.SeoKeyWord, c.DateCreated));
            
            CreateMap<TagViewModel, Tag>()
            .ConstructUsing(c => new Tag(c.Name,c.DateCreated,c.DateModifiled));
        }
    }
}
