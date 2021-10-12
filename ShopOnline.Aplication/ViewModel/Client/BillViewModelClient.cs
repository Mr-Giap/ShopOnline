using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Enum;

namespace ShopOnline.Aplication.ViewModel.Client
{
    public class BillViewModelClient
    {
        public Guid UserId { get; set; }
        public StatusBill Status { get; set; }
        public PaymentMethodType PaymentsMethod { get; set; }
    }

}
