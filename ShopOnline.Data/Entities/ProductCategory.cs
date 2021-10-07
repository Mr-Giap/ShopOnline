using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    public class ProductCategory : DomainEntity<int>
    {
        public int IdProduct { get; set; }
        public int IdCategoty { get; set; }

        //Dùng virtal sẽ sử dụng Lazy Loading trong bảng(1-n) còn nếu query 1 lần khi sử dụng bảng(1-1)thì dùng Explicit Loading.
        public virtual Product Product { get; set; }
        public virtual Category Category { get; set; }
    }
}
