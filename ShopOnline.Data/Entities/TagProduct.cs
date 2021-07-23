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
        public virtual Product Products { get; set; }
        public virtual Tag Tags { get; set; }
    }
}
