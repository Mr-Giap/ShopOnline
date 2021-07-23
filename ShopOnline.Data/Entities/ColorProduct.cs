using System;
using System.Collections.Generic;
<<<<<<< HEAD
=======
using System.ComponentModel.DataAnnotations.Schema;
>>>>>>> origin/khainv6-dev
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
<<<<<<< HEAD
=======
    [Table("ColorProducts")]
>>>>>>> origin/khainv6-dev
    public class ColorProduct: DomainEntity<int>
    {
        public int IdProduct { get; set; }
        public int IdColor { get; set; }
        // khóa ngoại của 2 bảng n- n
<<<<<<< HEAD
       public  IEnumerable<Product> Products { get; set; }
       public  IEnumerable<Color> Colors { get; set; }
=======
       public virtual Product Product { get; set; }
       public virtual Color Color { get; set; }
>>>>>>> origin/khainv6-dev
    }
}
