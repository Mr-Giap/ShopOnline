using ShopOnline.Data.Interface;
using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{

    [Table("Reviews")]
    public class Review : DomainEntity<int>, IHasDate
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public int Rate { get; set; }
        public bool IsShow { get; set; }
        public DateTime DateCreated { get ; set ; }
        public DateTime DateModifiled { get; set; }
        //Dùng virtal sẽ sử dụng Lazy Loading trong bảng(1-n) còn nếu query 1 lần khi sử dụng bảng(1-1)thì dùng Explicit Loading.
        public virtual Product Product { get; set; }


    }
}
