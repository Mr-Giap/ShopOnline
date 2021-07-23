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
        public string Name { get; set; }
        public IEnumerable<ColorProduct> ColorProducts { get; set; }
    }
}
