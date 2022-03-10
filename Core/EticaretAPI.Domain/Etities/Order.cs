using EticaretAPI.Domain.Etities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EticaretAPI.Domain.Etities
{
    public  class Order:BaseEntity
    {
        //Eğer customerId koymazsak entity framework otomatik kendi koyacaktır.Koyar isek bu id ile customeri ilişkilendirecektir.
        public Guid CustomerId { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }

        //Bir orderın birden fazla productu olduğu anlamına geliyor.
        public ICollection<Product> Products { get; set; }
        //Bire çok ilişki olduğu için sadece customer yazıyoruz.
        public Customer Customer { get; set; }
    }
}
