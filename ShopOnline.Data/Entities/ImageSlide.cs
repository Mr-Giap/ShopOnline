﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    [Table("ImageSlides")]
    public  class ImageSlide:DomainEntity<int>
    {
        public int IdSlide { get; set; }
        public int IdImage { get; set; }
        public string SrcButton { get; set; }

        public virtual Slide slide { get; set; }
        public virtual Image image{ get; set; }
    }
}
