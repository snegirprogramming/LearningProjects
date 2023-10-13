using System;
using System.Collections.Generic;

namespace Warehouse.Data.SQLite
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
        public string FreightCost { get; set; } = null!;

        public virtual ICollection<LineItem> LineItems { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
