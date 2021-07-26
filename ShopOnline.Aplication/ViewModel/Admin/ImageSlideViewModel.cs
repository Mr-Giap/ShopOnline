using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Aplication.ViewModel.Admin
{
 public   class ImageSlideViewModel
    {
        public int Id { get; set; }
        public int IdSlide { get; set; }
        public int IdImage { get; set; }
        public string SrcButton { get; set; }

        public IEnumerable <SlideViewModel> slide { get; set; }
        public IEnumerable <ImageViewModel> image { get; set; }
    }
}
