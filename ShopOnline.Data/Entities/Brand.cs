using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{

    [Table("Brands")]
    public class Brand : DomainEntity<int>
    {
        public string Name { get; set; }
        public int ImageId { get; set; }
        public bool IsShow { get; set; }
        public IEnumerable<Image> Images { get; set; }
    }
}
