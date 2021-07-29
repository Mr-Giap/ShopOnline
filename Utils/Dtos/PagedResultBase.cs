using System;
using System.Collections.Generic;
using System.Text;

namespace Utils.Dtos
{
   public abstract class PagedResultBase
    {
        public int CurrentPage { get; set; } // property 
        public int PageCount // tổng số page
        {
            get
            {
                var pageCount = (double)RowCount / PageSize;
                return (int)Math.Ceiling(pageCount);
            }
            set
            {
                PageCount = value;
            }
        }
        public int PageSize { get; set; }
        public int RowCount { get; set; } // số lượng bản ghi lấy ra
        public int FirstRowOnPage
        {
            get
            {
                return (CurrentPage - 1) * PageSize + 1;
            }
        }
        public int LastRowOnPage
        {
            get
            {
                return Math.Min(CurrentPage * PageSize, RowCount);
            }
        }
    }
}
