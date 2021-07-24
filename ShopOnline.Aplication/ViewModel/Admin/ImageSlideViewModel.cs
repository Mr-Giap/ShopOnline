using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Aplication.ViewModel.Admin
{
    public class ImageSlideViewModel
    {
        public int Id { get; set; }
        public string Src { get; set; }
        public int IdSlide { get; set; }
        public int IdImage { get; set; }
        public IEnumerable<SlideViewModel> Slides { get; set; }
        public IEnumerable<ImageViewModel> Images { get; set; }
    }
}
