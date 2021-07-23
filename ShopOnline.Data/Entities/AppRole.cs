using Microsoft.AspNetCore.Identity;
using ShopOnline.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    public class AppRole: IdentityRole<Guid>, IHasDate
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateModifiled { get; set; }
    }
}
