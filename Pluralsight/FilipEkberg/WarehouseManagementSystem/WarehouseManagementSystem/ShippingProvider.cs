using System;
using System.Collections.Generic;

namespace WarehouseManagementSystem
{
    public partial class ShippingProvider
    {
        public ShippingProvider()
        {
            LineItems = new HashSet<LineItem>();
            Orders = new HashSet<Order>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal FreightCost { get; set; }

        public virtual ICollection<LineItem> LineItems { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
