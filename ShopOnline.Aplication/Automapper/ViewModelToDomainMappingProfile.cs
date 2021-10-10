using AutoMapper;
using ShopOnline.Aplication.ViewModel.Admin;
using ShopOnline.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Aplication.Automapper
{
   public class ViewModelToDomainMappingProfile : Profile
    {

        public ViewModelToDomainMappingProfile()
        {
            // Khởi tạo ra 1 phương thức mapper để ánh xạ từ object này sang object khác.
            CreateMap<AppUserViewModel, AppUser>()
            .ConstructUsing(c => new AppUser(c.Id, c.Email, c.UserName, c.PhoneNumber, c.FullName,
            c.Address, c.Avatar, c.Status,c.DateCreated));

            CreateMap<AppRoleViewModel, AppRole>()
           .ConstructUsing(c => new AppRole(c.Id,c.Name,c.DateCreated));
            // produc
            CreateMap<ProductViewModel, Product>()
            .ConstructUsing(p => new Product(p.Id, p.Name, p.Price, p.PricePromotion,p.NameAscii,
            p.Description, p.Amount,p.IsShow,p.DisplayOrder,p.SeoDescription,p.SeoTitle,p.SeoKeyWord));
            //category
            CreateMap<CategoryViewModel, Category>()
            .ConstructUsing(c => new Category(c.Id,c.Name,c.NameAscii, c.ParentId,c.IsShow,c.DisplayOrder,
            c.SeoDescription,c.SeoTitle,c.SeoKeyWord));
            //Slide
            CreateMap<SlideViewModel, Slide>()
                .ConstructUsing(s => new Slide(s.Id,s.IsShow));
            //Color
            CreateMap<ColorViewModel, Color>()
               .ConstructUsing(c => new Color(c.Id,c.Name));
            //tag
            CreateMap<TagViewModel, Tag>()
               .ConstructUsing(c => new Tag(c.Id, c.Name));
            CreateMap<BillViewModel, Bill>()
              .ConstructUsing(b => new Bill(b.Id,b.UserId,b.Status,b.PaymentsMethod));
        }
    }
}
