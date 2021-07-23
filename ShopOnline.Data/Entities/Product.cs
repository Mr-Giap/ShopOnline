﻿using ShopOnline.Data.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    [Table("Products")]
    public class Product : DomainEntity<int>, IHasDate, IHasSort, IHasSeo
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public int IsShow { get; set; }
        public decimal PricePromotion { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModifiled { get; set; }
        public int DisplayOrder { get; set; }
        public string SeoDescription { get; set; }
        public string SeoTitle { get; set; }
        public string SeoKeyWord { get; set; }
    }
}
