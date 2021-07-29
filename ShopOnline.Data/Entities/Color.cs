using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    [Table("Colors")]
    public class Color:DomainEntity<int>
    {
        public Color()
        {

        }
        public Color(int id,string name)
        {
            Id = id;
            Name = name;
        }

        public string Name { get; set; }
        // Nếu ko lấy data thì dùng IEnumerable còn nếu muốn lấy thì thêm virtual IEnumerable.
        public virtual IEnumerable<ColorProduct> ColorProducts { get; set; }
    }
}
