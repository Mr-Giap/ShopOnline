using Microsoft.AspNetCore.Identity;
using ShopOnline.Data.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    [Table("AppRoles")]
    public class AppRole: IdentityRole<Guid>, IHasDate
    {
        public AppRole()
        {

        }
        public AppRole(Guid id,string name,DateTime dateTime)
        {
            Id = id;
            Name = name;
            DateCreated = dateTime;
        }

        public DateTime DateCreated { get; set; }
        public DateTime DateModifiled { get; set; }
    }
}
