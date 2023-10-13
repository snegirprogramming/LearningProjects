using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.Infrastructure.Data;

namespace WarehouseManagementSystem.Infrastructure
{
    public class ShippingProviderRepository : GenericRepository<ShippingProvider>
    {
        public ShippingProviderRepository(WarehouseContext context)
            : base(context)
        {
        }
    }
}
