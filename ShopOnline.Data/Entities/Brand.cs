using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    public class Brand : DomainEntity<int>
    {
        public string Name { get; set; }
        public int ImageId { get; set; }
        public int IsShow { get; set; }
        public IEnumerable<Image> Images { get; set; }
    }
}
