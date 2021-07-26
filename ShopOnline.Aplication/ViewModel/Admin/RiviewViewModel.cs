using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Aplication.ViewModel.Admin
{
  public  class RiviewViewModel
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public int Rate { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModifiled { get; set; }
        public int DisplayOrder { get; set; }
        public int IdProduct { get; set; }
        public IEnumerable <ProductViewModel> product { get; set; }
    }
}
