using EticaretAPI.Domain.Etities;
using EticaretAPI.Domain.Etities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EticaretAPI.Persistance.Contexts
{
    public class ETicaretAPIDbContext : DbContext
    {
        public ETicaretAPIDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders{ get; set; }
        public DbSet<Customer> Customers{ get; set; }

        /// <summary>
        /// Bizim için interceptor görevi görüyor.
        /// WriteRepository içerisinde hangi SaveChangesAsync fonksiyonu kullanıldıysa onu kullanmak durumundayız.
        /// Yani her SaveChanges tetiklendiğinde araya girip istediğimiz işlemi yaptırıp ardından SaveChangesAsync tekrar devreye sokabiliriz.
        /// </summary>
        /// <returns></returns>
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //Entityler üzerinden yapılan değişikliklerin ya da yeni eklenen verinin yakalanmasını sağlayan propertydir.Update operasyonlarında Track edilen verileri yakalayıp ele etmemizi sağlar.
            //Entries değişiklik yapılan bütün girdileri getiriyor.Sürece giren girdilerden herhangi bir türü burda seçebiliyoruz.
            var datas=ChangeTracker.Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _=data.State switch
                {
                    EntityState.Added=>data.Entity.CreatedDate=DateTime.UtcNow,
                    EntityState.Modified=>data.Entity.UpdatedDate=DateTime.UtcNow,
                };
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
