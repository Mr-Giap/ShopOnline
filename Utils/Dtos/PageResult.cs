using System;
using System.Collections.Generic;
using System.Text;

namespace Utils.Dtos
{
    public class PageResult<T> : PagedResultBase where T : class
    {
        public PageResult()
        {
            Results = new List<T>();
        }
        public T Result { get; set; }
        public IList<T> Results { get; set; }
    }
}
