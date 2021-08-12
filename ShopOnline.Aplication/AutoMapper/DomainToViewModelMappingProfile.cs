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
public   class DomainToViewModelMappingProfile:Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<AppUser, AppUserViewModel>();
            CreateMap<AppRole, AppRoleViewModel>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Slide, SlideViewModel>();
            CreateMap<Color, ColorViewModel>();
            CreateMap<Tag, TagViewModel>();
            CreateMap<Bill, BillViewModel>();

        }

    }
}
