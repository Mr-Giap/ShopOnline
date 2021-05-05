using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    public class Image: DomainEntity<int>
    {
       
        [Required]
        public string Src { get; set; }
    }
}
