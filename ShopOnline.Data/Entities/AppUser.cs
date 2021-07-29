using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ShopOnline.Data.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Enum;

namespace ShopOnline.Data.Entities
{
    [Table("AppUsers")]
    public class AppUser : IdentityUser<Guid>,IHasDate
    {
        public AppUser()
        {
            // contructor ko có tham số
        }

        public AppUser(Guid id,string email,string username,string phonenumber,string fullName, string address, string avatar, Status status,DateTime datetime)
        {
            Id = id;
            Email = email;
            UserName = username;
            PhoneNumber = phonenumber;
            FullName = fullName;
            Address = address;
            Avatar = avatar;
            Status = status;
            DateCreated = datetime;
        }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Avatar { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModifiled { get; set; }
        public Status Status { get; set; }
    }
}
