using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Aplication.ViewModel.Admin
{
   public class BillDetailViewModel
    {
        public int Id { get; set; }
        public int BillId { get; set; }
        public int Amount { get; set; }
        public int ProductId { get; set; }
        public string Note { get; set; }
        public int ColorId { get; set; }
        public int SizeId { get; set; }
        public IEnumerable <BillViewModel> Bill { get; set; }
    }
}
