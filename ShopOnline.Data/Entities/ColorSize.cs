using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
   public class ColorSize:DomainEntity<int>
    {
        public int IdSize { get; set; }
        public int IdColorProduct { get; set; }

        public IEnumerable<Size> sizes { get; set; }
        public IEnumerable<ColorProduct> colorProducts { get; set; }
    }
}
