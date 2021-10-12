using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Aplication.ViewModel.Client
{
    public class ProductViewModelClient
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal PricePromotion { get; set; }
        public string Description { get; set; }
        public string SeoDescription { get; set; }
        public string SeoTitle { get; set; }
        public string SeoKeyWord { get; set; }
    }
}
