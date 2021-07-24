using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Aplication.ViewModel.Admin
{
    public class ColorSizeViewModel
    {
        public int Id { get; set; }
        public int IdSize { get; set; }
        public int IdColorProduct { get; set; }
        public IEnumerable<SizeViewModel> Size { get; set; }
        public IEnumerable<ColorProductViewModel> ColorProduct { get; set; }
    }
}
