using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    [Table("ColorProducts")]
    public class ColorProduct: DomainEntity<int>
    {
        public int IdProduct { get; set; }
        public int IdColor { get; set; }
        // khóa ngoại của 2 bảng n- n
       public virtual Product Product { get; set; }
       public virtual Color Color { get; set; }
    }
}
