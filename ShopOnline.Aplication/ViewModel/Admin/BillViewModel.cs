using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Enum;

namespace ShopOnline.Aplication.ViewModel.Admin
{
    public class BillViewModel
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public StatusBill Status { get; set; }
        public PaymentMethodType PaymentsMethod { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModifiled { get; set; }
        public IEnumerable<AppUserViewModel> User { get; set; }
    }
}
