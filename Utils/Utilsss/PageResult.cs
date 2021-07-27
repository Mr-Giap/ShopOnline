using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Utilsss
{
    public class PageResult<T> : PageResultBase where T : class
    {
        public PageResult()
        {
            Results = new List<T>();
        }
        public T Result { get; set; }
        public IList<T> Results { get; set; }
    }
}
