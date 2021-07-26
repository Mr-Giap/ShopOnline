using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Aplication.ViewModel.Admin
{
  public  class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ParentId { get; set; }
        public bool IsShow { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModifiled { get; set; }

        public int DisplayOrder { get; set; }
        public string SeoDescription { get; set; }
        public string SeoTitle { get; set; }
        public string SeoKeyWord { get; set; }
    }
}
