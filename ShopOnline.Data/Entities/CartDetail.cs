using ShopOnline.Data.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    [Table("CartDetails")]
    public class CartDetail : DomainEntity<int>, IHasDate
    {
        public decimal Amount { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModifiled { get; set; }

    }
}
