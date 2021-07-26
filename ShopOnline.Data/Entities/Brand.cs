using ShopOnline.Data.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    [Table("Brands")]

    public class Brand : DomainEntity<int>, IHasSort
    {
        [StringLength(160, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }
        public string ImageId { get; set; }
        public int DisplayOrder {get;set;}
        public IEnumerable <Image> images { get; set; }
    }
}
