using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
  public  class ProductCategory
    {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        public int IdCategory { get; set; }
        public virtual Product Product { get; set; }
        public virtual Category Category { get; set; }
       

    }
}
