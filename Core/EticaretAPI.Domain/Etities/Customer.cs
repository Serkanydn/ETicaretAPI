using EticaretAPI.Domain.Etities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EticaretAPI.Domain.Etities
{
    public class Customer: BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Order> Orders{ get; set; }
    }
}
