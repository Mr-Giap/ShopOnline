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
           public Category(string name,string parentId,bool isShow, int disPlayOrder, string seoDescription,string seoTitle, string seoKeyWord)
        {
             Name=name;
            ParentId=parentId;
            IsShow=isShow;
            DisplayOrder=disPlayOrder;
            SeoDescription=seoDescription;
            SeoTitle=seoTitle;
            SeoKeyWord=seoKeyWord;
        }

        [Required]
        [Display(Name = "ProductName")]
        public string Name { get; set; }
        public string NameAcsii { get; set; }

        public string ParentId { get; set; }
        public bool IsShow { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModifiled { get; set; }
        
        public int DisplayOrder { get; set; }
        public string SeoDescription { get; set; }
        public string SeoTitle { get; set; }
        public string SeoKeyWord { get; set; }
        public virtual IEnumerable<ProductCategory> ProductCategories { get;set;}
    }
}
