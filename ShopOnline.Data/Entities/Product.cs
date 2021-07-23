using ShopOnline.Data.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
<<<<<<< HEAD
=======
    [Table("Products")]
>>>>>>> origin/khainv6-dev
    public class Product : DomainEntity<int>, IHasDate, IHasSort, IHasSeo
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
<<<<<<< HEAD
        public decimal PricePromotion { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public int IsShow { get; set; }
        public DateTime DateCreated { get; set ; }
=======
        public int Amount { get; set; }
        public int IsShow { get; set; }
        public decimal PricePromotion { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
>>>>>>> origin/khainv6-dev
        public DateTime DateModifiled { get; set; }
        public int DisplayOrder { get; set; }
        public string SeoDescription { get; set; }
        public string SeoTitle { get; set; }
        public string SeoKeyWord { get; set; }
    }
}
