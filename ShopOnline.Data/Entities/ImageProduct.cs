﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    [Table("ImagesProduct")]
    public class ImageProduct : DomainEntity<int>
    {
        public int IdProduct { get; set; }
        public int IdImage { get; set; }

        public  virtual Product Product { get; set; }
        public  virtual Image Image { get; set; }

    }
}
