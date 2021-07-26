using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Aplication.ViewModel.Admin
{
   public class ImageProductViewModel
    {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        public int IdImage { get; set; }

        public IEnumerable< ProductViewModel> Product { get; set; }
        public IEnumerable <ImageViewModel> Image { get; set; }
    }
}
