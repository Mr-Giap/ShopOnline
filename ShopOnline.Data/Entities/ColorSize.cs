using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{

    [Table("ColorSizes")]

    public class ColorSize: DomainEntity<int>
    {
        public int IdSize { get; set; }
        public int IdColorProduct { get; set; }
        //Dùng virtal sẽ sử dụng Lazy Loading trong bảng(1-n) còn nếu query 1 lần khi sử dụng bảng(1-1)thì dùng Explicit Loading.
        public virtual Size Size { get; set; }
        public virtual ColorProduct ColorProduct { get; set; }

    }
}
