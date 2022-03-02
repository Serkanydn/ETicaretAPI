using EticaretAPI.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EticaretAPI.Persistance
{
    public static class ServiceRegistration
    {
        //Program.csde tetiklememiz gerekiyor.
        public static void AddPersistanceServices(this IServiceCollection services)
        {
            //Onion Architecturede katmanlar arası bir sınıfı göndermek istiyorsak bu sınıfı kullanıyoruz.
            services.AddDbContext<ETicaretAPIDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));
        }
    }
}
