using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    [Table("ImageProducts")]
    public class ImageProduct : DomainEntity<int>
    {
        public int IdProduct { get; set; }
        public int IdImage { get; set; }
        // khóa ngoại của 2 bảng n- n (Products and Images)

        //Dùng virtal sẽ sử dụng Lazy Loading trong bảng(1-n) còn nếu query 1 lần khi sử dụng bảng(1-1)thì dùng Explicit Loading.
        public virtual Product Product { get; set; }
        public virtual Image Image { get; set; }
        //bảng thì đặt tên số nhiều còn trường dữ liệu thì đặt tên số ít

    }
}
