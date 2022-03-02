using EticaretAPI.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EticaretAPI.Persistance
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ETicaretAPIDbContext>
    {
        //Bazen visual studioda çalışamıyoruz ve mig oluşturmamız gerekebiliyor böyle durumlarda hata almamamız için bu configureyi yapmamız gerekiyor.
        //Sana dotnet clidan mig talebi gelirse onu bu şekilde ayarla
        public ETicaretAPIDbContext CreateDbContext(string[] args)
        {
        
            DbContextOptionsBuilder<ETicaretAPIDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer(Configuration.ConnectionString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
