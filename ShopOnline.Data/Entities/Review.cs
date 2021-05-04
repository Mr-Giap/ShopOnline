using ShopOnline.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    public class Review : DomainEntity<int>, IHasDate
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public int Rate { get; set; }
        public int IsShow { get; set; }
        public DateTime DateCreated { get ; set ; }
        public DateTime DateModifiled { get; set; }
        public IEnumerable<Product> Products { get; set; }

    }
}
