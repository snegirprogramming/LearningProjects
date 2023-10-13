using System;
using System.Collections.Generic;

namespace WarehouseManagementSystem.Infrastructure.Data
{
    public class Customer
    {
        private byte[]? _logo;

        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

        public byte[]? Logo
        {
            get
            {
                if (Logo is null)
                {
                    Logo = LogoService.GetFor(Name);
                }
                return Logo;
            }
            set => _logo = value;
        }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
