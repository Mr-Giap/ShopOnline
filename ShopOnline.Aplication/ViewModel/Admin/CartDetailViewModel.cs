
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Aplication.ViewModel.Admin
{
    public class CartDetailViewModel
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }
        public IEnumerable<ProductViewModel> Products { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModifiled { get; set; }
    }
}
