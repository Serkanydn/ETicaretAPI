using EticaretAPI.Domain.Etities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Repositories
{
    //constrait
    public  interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
