using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Aplication.ViewModel.Admin
{
    public class ColorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public  IEnumerable<ColorProductViewModel> ColorProduct { get; set; }
    }
}
