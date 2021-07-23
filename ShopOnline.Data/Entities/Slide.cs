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
    [Table("Slides")]
>>>>>>> origin/khainv6-dev
    public class Slide : DomainEntity<int>, IHasDate
    {
        public int IsShow { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModifiled { get; set; }
    }
}
