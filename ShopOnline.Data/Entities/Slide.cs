﻿using ShopOnline.Data.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{

    [Table("Slides")]
    public class Slide : DomainEntity<int>, IHasDate
    {
        public int IsShow { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModifiled { get; set; }
    }
}
