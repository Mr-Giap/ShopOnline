using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    public class ImageSlide : DomainEntity<int>
    {
        public string Src { get; set; }
        public int IdSlide { get; set; }
        public int IdImage { get; set; }
        public IEnumerable<Slide> Slides { get; set; }
        public IEnumerable<Image> Images{ get; set; }

    }
}
