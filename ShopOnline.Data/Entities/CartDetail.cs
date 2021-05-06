using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    public class CartDetail : DomainEntity<int>
    {
        public decimal Amount { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }
        public IEnumerable<Product> Products { get; set; }

    }
}
