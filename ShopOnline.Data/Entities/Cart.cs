using ShopOnline.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    public class Cart : DomainEntity<int>, IHasDate
    {
        public decimal TotalPrice { get; set; }
        public bool Status { get; set; }
        public int UserId { get; set; }
        public string ShippingAddress { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime DateCreated {get;set;}
        public DateTime DateModifiled {get;set;}
    }
}
