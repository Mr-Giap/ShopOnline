using Microsoft.AspNetCore.Identity;
using ShopOnline.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Enum;

namespace ShopOnline.Data.Entities
{
   public class AppUser: IdentityUser<Guid>,IHasDate
    {
        public AppUser()
        {
        }

        public AppUser(Guid id, string email, string username, string phonenumber, string fullName, string address, string avatar, Status status,DateTime dateCreated,DateTime dateModifiled)
        {
            Id = id;
            Email = email;
            UserName = username;
            FullName = fullName;
            Address = address;
            Avatar = avatar;
            this.status = status;
            PhoneNumber = phonenumber;
            DateCreated = dateCreated;
            DateModifiled = dateModifiled;

        }

        public string FullName { get; set; }
        public string Address { get; set; }
        public string Avatar { get; set; }
        public  Status status { get; set; }
        public DateTime DateCreated { get ; set; }
        public DateTime DateModifiled { get ; set; }
    }
}
