using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Interface
{
    public interface IHasDate
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateModifiled { get; set; }
    }
}
