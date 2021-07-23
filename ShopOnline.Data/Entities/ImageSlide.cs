using System;
using System.Collections.Generic;
<<<<<<< HEAD
=======
using System.ComponentModel.DataAnnotations.Schema;
>>>>>>> origin/khainv6-dev
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
<<<<<<< HEAD
=======
    [Table("ImageSlides")]
>>>>>>> origin/khainv6-dev
    public class ImageSlide : DomainEntity<int>
    {
        public string Src { get; set; }
        public int IdSlide { get; set; }
        public int IdImage { get; set; }
<<<<<<< HEAD
        public IEnumerable<Slide> Slides { get; set; }
        public IEnumerable<Image> Images{ get; set; }
=======
        public virtual Slide Slide { get; set; }
        public virtual Image Image{ get; set; }
>>>>>>> origin/khainv6-dev

    }
}
