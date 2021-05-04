using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    public class ImageProduct : DomainEntity<int>
    {
        public int IdProduct { get; set; }
        public int IdImage { get; set; }

        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Image> Images { get; set; }

    }
}
