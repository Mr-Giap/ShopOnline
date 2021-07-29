using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    [Table("Tags")]
    public class Tag: DomainEntity<int>
    {
        public Tag()
        {

        }
        public Tag(int id,string name)
        {
            Id = id;
            Name = name;
        }

        public string Name { get; set; }
    }
}
