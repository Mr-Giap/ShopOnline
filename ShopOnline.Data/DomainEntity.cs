using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data
{
    public abstract class DomainEntity<T>
    {
        public T Id { get; set; }
    }
}
