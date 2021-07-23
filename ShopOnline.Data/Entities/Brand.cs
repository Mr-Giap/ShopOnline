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
    [Table("Brands")]
>>>>>>> origin/khainv6-dev
    public class Brand : DomainEntity<int>
    {
        public string Name { get; set; }
        public int ImageId { get; set; }
        public int IsShow { get; set; }
<<<<<<< HEAD
        public IEnumerable<Image> Images { get; set; }
=======
        public virtual Image Image { get; set; }
>>>>>>> origin/khainv6-dev
    }
}
