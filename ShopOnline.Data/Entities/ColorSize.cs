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
    [Table("ColorSizes")]
>>>>>>> origin/khainv6-dev
    public class ColorSize: DomainEntity<int>
    {
        public int IdSize { get; set; }
        public int IdColorProduct { get; set; }
<<<<<<< HEAD
        public IEnumerable<Size> Sizes { get; set; }
        public IEnumerable<ColorProduct> ColorProducts { get; set; }
=======
        public virtual Size Size { get; set; }
        public virtual ColorProduct ColorProduct { get; set; }
>>>>>>> origin/khainv6-dev


    }
}
