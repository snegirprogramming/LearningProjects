using Moq;
using System.Security.Cryptography.X509Certificates;
using WarehouseManagementSystem.Infrastructure;
using WarehouseManagementSystem.Infrastructure.Data;
using WarehouseManagementSystem.Web.Controllers;
using WarehouseManagementSystem.Web.Models;

namespace WarehouseManagementSystem.Web.Tests
{
    [TestClass]
    public class OrderControllerTests
    {
        //[TestMethod]
        //public void CanCreateOrderWithCorrectModel()
        //{
        //    // ARRANGE
        //    var orderRepository = new Mock<IRepository<Order>>();
        //    var itemRepository = new Mock<IRepository<Item>>();
        //    var shippingProviderRepository = new Mock<IRepository<ShippingProvider>>();

        //    shippingProviderRepository
        //        .Setup(x => x.All())
        //        .Returns(new[] { new ShippingProvider() });

        //    var orderController = new OrderController(
        //        orderRepository.Object,
        //        shippingProviderRepository.Object,
        //        itemRepository.Object);

        //    var createOrderModel = new CreateOrderModel
        //    {
        //        Customer = new()
        //        {
        //            Name = "Filip Ekberg",
        //            Address = "Kungsbacka",
        //            PostalCode = "434 94",
        //            Country = "Sweden",
        //            PhoneNumber = "+46 555 123 123",
        //        },
        //        LineItems = new[]
        //        {
        //            new LineItemModel
        //            {
        //                ItemId = Guid.NewGuid(),
        //                Quantity = 100,
        //            }
        //        }
        //    };

        //    // ACT
        //    orderController.Create(createOrderModel);

        //    // ASSERT
        //    orderRepository.Verify(
        //        x => x.Add(It.IsAny<Order>()), Times.AtMostOnce());
        //}
    }
}