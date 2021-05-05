using ShopOnline.Data.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    public class Review:DomainEntity<int>,IHasDate, IHasSort
    {
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }
        public string Content { get; set; }
        public int Rate { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModifiled { get; set; }
        public int DisplayOrder { get; set; }
        public int IdProduct { get; set; }
        public IEnumerable<Product>products { get; set; }
    }
}
