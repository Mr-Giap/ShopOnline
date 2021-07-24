using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    [Table("ColorProducts")]
    public class ColorProduct: DomainEntity<int>
    {
        public int IdProduct { get; set; }
        public int IdColor { get; set; }
        // khóa ngoại của 2 bảng n- n
        /// <summary>
        /// Vì sao để virtal : vì liên kết n-n để bảng đơn không phải để kiểu list
        /// Tại sao để bảng đơn vì ColorProduct có 1 row và mỗi 1 row chỉ để đc 1 sản phẩm
        ///  Dùng virtal sẽ sử dụng Lazy Loading trong bảng(1-n) còn nếu query 1 lần khi sử dụng bảng(1-1)thì dùng Explicit Loading.
        /// </summary>
        public virtual Product Product { get; set; }
        public virtual Color Color { get; set; }

    }
}
