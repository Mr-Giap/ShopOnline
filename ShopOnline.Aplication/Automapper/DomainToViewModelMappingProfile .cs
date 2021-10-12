using AutoMapper;
using ShopOnline.Aplication.ViewModel.Admin;
using ShopOnline.Aplication.ViewModel.Client;
using ShopOnline.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Aplication.Automapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            // config chuyển đổi từ AppUser => AppUserViewModel
            CreateMap<AppUser, AppUserViewModel>();
            CreateMap<AppRole, AppRoleViewModel>();
            CreateMap<Bill, BillViewModel>();
            CreateMap<Slide, SlideViewModel>();
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<Color, ColorViewModel>();
            CreateMap<Tag, TagViewModel>();
            //Client
            CreateMap<Product, ProductViewModelClient>();
            CreateMap<AppUser, UserModel>();
            CreateMap<Category, CategoryViewModelClient>();
            CreateMap<Bill, BillViewModelClient>();
            CreateMap<Color, ColorViewModelClient>();
            CreateMap<Tag, TagViewModelClient>();
            //CreateMap<Slide, SlideViewModelClient>();
        }
    }
}
