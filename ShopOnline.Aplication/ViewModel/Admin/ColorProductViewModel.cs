﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Aplication.ViewModel.Admin
{
    public class ColorProductViewModel
    {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        public int IdColor { get; set; }
        public IEnumerable<ProductViewModel>Product { get; set; }
        public IEnumerable<ColorViewModel> Color { get; set; }

    }
}
