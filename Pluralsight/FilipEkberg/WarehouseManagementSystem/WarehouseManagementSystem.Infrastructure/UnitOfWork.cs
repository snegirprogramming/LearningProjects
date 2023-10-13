using WarehouseManagementSystem.Infrastructure.Data;

namespace WarehouseManagementSystem.Infrastructure
{
    public interface IUnitOfWork
    {
        IRepository<Order> OrderRepository { get; }
        IRepository<Item> ItemRepository { get; }
        IRepository<ShippingProvider> ShippingProviderRepository { get; }
        IRepository<Customer> CustomerRepository { get; }

        void SaveChanges();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private WarehouseContext context;

        public UnitOfWork(WarehouseContext context)
        {
            this.context = context;
        }

        private IRepository<Customer> customerRepository;
        private IRepository<Order> orderRepository;
        private IRepository<Item> itemRepository;
        private IRepository<ShippingProvider> shippingProviderRepository;

        public IRepository<Order> OrderRepository
        {
            get
            {
                if (orderRepository is null)
                {
                    orderRepository = new OrderRepository(context);
                }
                return orderRepository;
            }
        }

        public IRepository<Customer> CustomerRepository
        {
            get
            {
                if (customerRepository is null)
                {
                    customerRepository = new CustomerRepository(context);
                }
                return customerRepository;
            }
        }

        public IRepository<Item> ItemRepository
        {
            get
            {
                if (itemRepository is null)
                {
                    itemRepository = new ItemRepository(context);
                }
                return itemRepository;
            }
        }
        
        public IRepository<ShippingProvider> ShippingProviderRepository
        {
            get
            {
                if (shippingProviderRepository is null)
                {
                    shippingProviderRepository = new ShippingProviderRepository(context);
                }
                return shippingProviderRepository;
            }
        }

        public void SaveChanges() => context.SaveChanges();
    }
}