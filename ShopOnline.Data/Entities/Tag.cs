﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
   public class Tag:DomainEntity<int>
    {
        public string Name { get; set; }
    }
}
