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
    [Table("TagProducts")]
>>>>>>> origin/khainv6-dev
    public class TagProduct: DomainEntity<int>
    {
        public int IdProduct { get; set; }
        public int IdTag { get; set; }
<<<<<<< HEAD
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
=======
        public virtual Product Products { get; set; }
        public virtual Tag Tags { get; set; }
>>>>>>> origin/khainv6-dev
    }
}
