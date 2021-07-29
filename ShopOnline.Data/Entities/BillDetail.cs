
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    [Table("BillDetails")]
    public class BillDetail : DomainEntity<int>
    {
        public int BillId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public int ColorId { get; set; }
        public int SizeId { get; set; }
        public string Note { get; set; }
        public virtual Bill Bill { get; set; }
    }
}
