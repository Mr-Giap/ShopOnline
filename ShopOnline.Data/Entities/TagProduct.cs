using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{

    [Table("TagProducts")]
    public class TagProduct: DomainEntity<int>
    {
        public int IdProduct { get; set; }
        public int IdTag { get; set; }
        //Dùng virtal sẽ sử dụng Lazy Loading(1-n) còn nếu query 1 lần khi sử dụng bảng thì dùng Explicit Loading.
        public virtual Product Product { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
