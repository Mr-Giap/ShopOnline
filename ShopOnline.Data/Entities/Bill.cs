using ShopOnline.Data.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Enum;

namespace ShopOnline.Data.Entities
{
    [Table("Bills")]
    public class Bill : DomainEntity<int>, IHasDate
    {
        public Bill()
        {

        }
        public Bill(int id,Guid userId, StatusBill status, PaymentMethodType paymentsMethod)
        {
            Id = id;
            UserId = userId;
            Status = status;
            PaymentsMethod = paymentsMethod;
        }

        public Guid UserId { get; set; }
        public StatusBill Status { get; set; }
        public PaymentMethodType PaymentsMethod{ get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModifiled { get; set; }
        public virtual AppUser User { get; set; }
             
    }
}
