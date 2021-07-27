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
        }

    }
}
