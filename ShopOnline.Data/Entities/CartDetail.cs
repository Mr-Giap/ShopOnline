<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
=======
﻿using ShopOnline.Data.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
>>>>>>> origin/khainv6-dev
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
<<<<<<< HEAD
    public class CartDetail : DomainEntity<int>
=======
    [Table("CartDetails")]
    public class CartDetail : DomainEntity<int>, IHasDate
>>>>>>> origin/khainv6-dev
    {
        public decimal Amount { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }
<<<<<<< HEAD
        public IEnumerable<Product> Products { get; set; }
=======
        public virtual Product Product { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModifiled { get; set; }
>>>>>>> origin/khainv6-dev

    }
}
