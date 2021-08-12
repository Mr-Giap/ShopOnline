﻿using ShopOnline.Data.Interface;
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

        public Bill(int Id,Guid userId, StatusBill status, DateTime dateCreated, DateTime dateModifiled, PaymentMethodType paymentMethod)
        {
            Id = Id;
            UserId = userId;
            Status = status;
            DateCreated = dateCreated;
            DateModifiled = dateModifiled;
            this.paymentMethod = paymentMethod;
        }

        public Guid UserId { get; set; }
        public StatusBill Status { get; set; }
        public DateTime DateCreated { get; set ; }
        public DateTime DateModifiled { get ; set ; }
        public PaymentMethodType paymentMethod { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
