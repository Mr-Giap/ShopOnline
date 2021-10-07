using ShopOnline.Data.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{

    [Table("Products")]
    public class Product : DomainEntity<int>, IHasDate, IHasSort, IHasSeo
    {
        public Product()
        {

        }
        public Product(int id,string name, decimal price, decimal pricePromotion, string description,string nameAscii, int amount, bool isShow, int displayOrder, string seoDescription, string seoTitle, string seoKeyWord)
        {
            Id = id;
            Name = name;
            Price = price;
            PricePromotion = pricePromotion;
            Description = description;
            NameAscii = nameAscii;
            Amount = amount;
            IsShow = isShow;
            DisplayOrder = displayOrder;
            SeoDescription = seoDescription;
            SeoTitle = seoTitle;
            SeoKeyWord = seoKeyWord;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }

        public decimal PricePromotion { get; set; }
        public string Description { get; set; }
        public string NameAscii { get; set; }
        public int Amount { get; set; }
        public bool IsShow { get; set; }
        public DateTime DateCreated { get; set ; }
        public DateTime DateModifiled { get; set; }
        public int DisplayOrder { get; set; }
        public string SeoDescription { get; set; }
        public string SeoTitle { get; set; }
        public string SeoKeyWord { get; set; }
        public virtual IEnumerable<ProductCategory> ProductCategory { get; set; }
    }
}
