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
        public int IsShow { get; set; }
        public DateTime DateCreated { get ; set ; }
        public DateTime DateModifiled { get; set; }
        public virtual Product Products { get; set; }

    }
}
