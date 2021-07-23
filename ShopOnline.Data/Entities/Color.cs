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
    public class Color:DomainEntity<int>
    {
        public string Name { get; set; }
=======
    [Table("Colors")]
    public class Color:DomainEntity<int>
    {
        public string Name { get; set; }
        public IEnumerable<ColorProduct> ColorProducts { get; set; }
>>>>>>> origin/khainv6-dev
    }
}
