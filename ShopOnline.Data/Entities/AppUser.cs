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
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Avatar { get; set; }
        public  Status status { get; set; }
        public DateTime DateCreated { get ; set; }
        public DateTime DateModifiled { get ; set; }
    }
}
