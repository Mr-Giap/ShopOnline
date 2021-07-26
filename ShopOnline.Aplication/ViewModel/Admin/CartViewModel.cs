using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Aplication.ViewModel.Admin
{
   public class CartViewModel
    {
        public Guid Id { get; set; }
        public decimal TotalPrice { get; set; }
        public bool Status { get; set; }
        public Guid UserId { get; set; }
        public string ShippingAddress { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModifiled { get; set; }
    }
}
