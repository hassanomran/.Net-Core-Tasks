using aspnetcore_n_tier.DAL.DataContext;
using aspnetcore_n_tier.DAL.Repositories.IRepositories;
using aspnetcore_n_tier.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnetcore_n_tier.DAL.Repositories
{
    public class WarehouseRepository : GenericRepository<Warehouse>, IWarehouseRepository
    {
        private readonly AspNetCoreNTierDbContext _aspNetCoreNTierDbContext;
        public WarehouseRepository(AspNetCoreNTierDbContext aspNetCoreNTierDbContext) : base(aspNetCoreNTierDbContext)
        {
            _aspNetCoreNTierDbContext = aspNetCoreNTierDbContext;
        }
    }
}
