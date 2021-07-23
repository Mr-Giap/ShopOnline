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
    [Table("Cars")]
>>>>>>> origin/khainv6-dev
    public class Cart : DomainEntity<int>, IHasDate
    {

        public decimal TotalPrice { get; set; }
        public int Status { get; set; }
<<<<<<< HEAD
        public int UserId { get; set; }
=======
        public Guid UserId { get; set; }
>>>>>>> origin/khainv6-dev
        public string ShippingAddress { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModifiled { get; set; }

    }
}
