using ShopOnline.Data.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    public class Brand : DomainEntity<int>, IHasSort
    {
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }
        public string ImageId { get; set; }
        public int DisplayOrder {get;set;}
    }
}
