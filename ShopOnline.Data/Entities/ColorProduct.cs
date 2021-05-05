using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
   public class ColorProduct : DomainEntity<int>
    {
        public int IdProduct { get; set; }
        public int IdColor{ get; set; }


        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Color> colors { get; set; }
    }
}
