using ShopOnline.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    public class Brand : DomainEntity<int>, IHasSort
    {
        public string Name { get; set; }
        public string ImageId { get; set; }
        public int DisplayOrder {get;set;}
    }
}
