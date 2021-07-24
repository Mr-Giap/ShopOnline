using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    [Table("ImageSlides")]
    public class ImageSlide : DomainEntity<int>
    {
        public string Src { get; set; }
        public int IdSlide { get; set; }
        public int IdImage { get; set; }
       //Dùng virtal sẽ sử dụng Lazy Loading trong bảng(1-n) còn nếu query 1 lần khi sử dụng bảng(1-1)thì dùng Explicit Loading.
        public virtual Slide Slide { get; set; }
        public virtual Image Image{ get; set; }
    }
}
