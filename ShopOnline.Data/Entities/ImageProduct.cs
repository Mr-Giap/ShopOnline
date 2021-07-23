using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    [Table("ImageProducts")]
    public class ImageProduct : DomainEntity<int>
    {
        public int IdProduct { get; set; }
        public int IdImage { get; set; }
<<<<<<< HEAD
        // khóa ngoại của 2 bảng n- n (Products and Images)
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Image> Images { get; set; }
=======

        public virtual Product Product { get; set; }
        public virtual Image Image { get; set; }
>>>>>>> origin/khainv6-dev

    }
}
