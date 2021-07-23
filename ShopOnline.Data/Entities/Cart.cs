using ShopOnline.Data.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    [Table("Cars")]
    public class Cart : DomainEntity<int>, IHasDate
    {

        public decimal TotalPrice { get; set; }
        public int Status { get; set; }
        public Guid UserId { get; set; }
        public string ShippingAddress { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModifiled { get; set; }

    }
}
