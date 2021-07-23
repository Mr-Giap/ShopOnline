using ShopOnline.Data.Interface;
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
    [Table("Reviews")]
>>>>>>> origin/khainv6-dev
    public class Review : DomainEntity<int>, IHasDate
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public int Rate { get; set; }
        public int IsShow { get; set; }
        public DateTime DateCreated { get ; set ; }
        public DateTime DateModifiled { get; set; }
<<<<<<< HEAD
        public IEnumerable<Product> Products { get; set; }
=======
        public virtual Product Products { get; set; }
>>>>>>> origin/khainv6-dev

    }
}
