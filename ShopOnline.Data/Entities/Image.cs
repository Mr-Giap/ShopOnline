using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    [Table("Images")]
    public class Image : DomainEntity<int>
    {
        public string Src { get; set; }
    }
}
