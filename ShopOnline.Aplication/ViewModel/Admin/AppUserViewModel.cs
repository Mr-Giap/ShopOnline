﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Enum;

namespace ShopOnline.Aplication.ViewModel.Admin
{
    public class AppUserViewModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string UserName { get; set; }

        public string PhoneNumber { get; set; }
        public string Avatar { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModifiled { get; set; }
        public Status Status { get; set; }
        public string PassWord { get; set; }
        // Tạo 1 list danh sách Roles
        public List<AppRoleViewModel> Roles { get; set; }

    }
}
