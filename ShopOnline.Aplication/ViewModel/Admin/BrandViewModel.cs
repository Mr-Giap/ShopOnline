using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Aplication.ViewModel.Admin
{
  public  class BrandViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageId { get; set; }
        public int DisplayOrder { get; set; }
        public IEnumerable<ImageViewModel> images { get; set; }
    }
}
