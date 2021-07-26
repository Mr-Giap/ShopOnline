using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    [Table("Sizes")]
    public class Size:DomainEntity<int>
    {
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }
    }
}
