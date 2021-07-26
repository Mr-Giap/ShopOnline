using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Aplication.ViewModel.Admin
{
  public  class CartDetailViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public IEnumerable <ProductViewModel> Product { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModifiled { get; set; }
    }
}
