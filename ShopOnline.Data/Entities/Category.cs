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
        public Category()
        {

        }

        public Category(int id, string name, string nameAscii, int parentId, bool isShow, int displayOrder, string seoDescription, string seoTitle, string seoKeyWord)
        {
            Id = id;
            Name = name;
            NameAscii = nameAscii;
            ParentId = parentId;
            IsShow = isShow;
            DisplayOrder = displayOrder;
            SeoDescription = seoDescription;
            SeoTitle = seoTitle;
            SeoKeyWord = seoKeyWord;

        }
        [Required]
        [Display(Name = "ProductName")]
        public string Name { get; set; }
        public string NameAscii { get; set; }
        public int ParentId { get; set; }
        public bool IsShow { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModifiled { get; set; }
        public int DisplayOrder { get; set; }
        public string SeoDescription { get; set; }
        public string SeoTitle { get; set; }
        public string SeoKeyWord { get; set; }
        //public virtual Bill Bill { get; set; }
        public virtual IEnumerable<ProductCategory> ProductCategory { get; set; }

    }
}
