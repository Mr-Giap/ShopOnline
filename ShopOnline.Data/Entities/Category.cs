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
    [Table("Categories")]
    public class Category : DomainEntity<int>, IHasDate, IHasSort, IHasSeo
    {
        [Required]
        [Display(Name = "ProductName")]
        public string Name { get; set; }
        public string ParentId { get; set; }
        public bool IsShow { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModifiled { get; set; }
        
        public int DisplayOrder { get; set; }
        public string SeoDescription { get; set; }
        public string SeoTitle { get; set; }
        public string SeoKeyWord { get; set; }
    }
}
