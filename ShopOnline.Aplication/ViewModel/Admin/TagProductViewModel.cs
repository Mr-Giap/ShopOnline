using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Aplication.ViewModel.Admin
{
  public  class TagProductViewModel
    {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        public int IdTag { get; set; }

        public IEnumerable <ProductViewModel> Product { get; set; }
        public IEnumerable <TagViewModel> tag { get; set; }
    }
}
