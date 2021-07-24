
using System.Collections.Generic;
﻿using ShopOnline.Data.Interface;
using System;
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
        /// <summary>
        /// Thêm IHasDate có thể sửa  trường của cartdetails vì ăn theo bảng cart 
        /// </summary>
        public DateTime DateCreated { get; set; }
        public DateTime DateModifiled { get; set; }

    }
}
