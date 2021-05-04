using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
  public  class ImageSlide:DomainEntity<int>
    {
        public int IdSlide { get; set; }
        public int IdImage { get; set; }
        public string SrcButton { get; set; }

        public IEnumerable<Slide> slides { get; set; }
        public IEnumerable<Image> images { get; set; }
    }
}
