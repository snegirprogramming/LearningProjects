using Microsoft.Data.SqlClient;

var connectionString =
    "Data Source=(LocalDB)\\MSSQLLocalDB;" +
    "Initial Catalog=WarehouseManagement;" +
    "Integrated Security=True;";

using SqlConnection connection = new(connectionString);

using SqlCommand command = new(@"
    INSERT INTO [Customers]
    (Id, Name, Address, PostalCode, Country, PhoneNumber)
    VALUES(NEWID(), @Name, @Address, @PostalCode, @Country, @PhoneNumber)
", connection);

var nameParameter = new SqlParameter("Name", System.Data.SqlDbType.NVarChar);
nameParameter.Value = Console.ReadLine().Trim();
command.Parameters.Add(nameParameter);

var addressParameter = new SqlParameter("Address", System.Data.SqlDbType.NVarChar);
addressParameter.Value = Console.ReadLine().Trim();
command.Parameters.Add(addressParameter);

var postalCodeParameter = new SqlParameter("PostalCode", System.Data.SqlDbType.NVarChar);
postalCodeParameter.Value = Console.ReadLine().Trim();
command.Parameters.Add(postalCodeParameter);

var countryParameter = new SqlParameter("Country", System.Data.SqlDbType.NVarChar);
countryParameter.Value = Console.ReadLine().Trim();
command.Parameters.Add(countryParameter);

var phoneNumberParameter = new SqlParameter("PhoneNumber", System.Data.SqlDbType.NVarChar);
phoneNumberParameter.Value = Console.ReadLine().Trim();
command.Parameters.Add(phoneNumberParameter);

connection.Open();

var rowsAffected = command.ExecuteNonQuery();

Console.WriteLine($"Rows affected: {rowsAffected}");
Console.ReadLine();








//using SqlCommand command = new(
//    "SELECT * FROM [Orders]" +
//    "INNER JOIN [Customers] ON " +
//    "[Customers].Id = [Orders].CustomerId", connection);

//connection.Open();

//using var reader = command.ExecuteReader();

//if (reader.HasRows == false)
//{
//    return;
//}

//while (reader.Read())
//{
//    var orderId = reader["Id"];
//    var customer = reader["Name"];

//    Console.WriteLine(orderId);
//    Console.WriteLine(customer);

//}

//Console.ReadLine();










//using Microsoft.EntityFrameworkCore;
//using WarehouseManagementSystem;

//Customer filip = new()
//{
//    Id = Guid.NewGuid(),
//    Name = "Filip Ekberg",
//    Address = "Kungsbacka",
//    PostalCode = "434 94",
//    Country = "Sweden",
//    PhoneNumber = "+46 111 111 111"
//};

//ShippingProvider shippingProvider = new()
//{
//    Id = Guid.NewGuid(),
//    Name = "Swedish Postal Service",
//    FreightCost = 100m
//};

//Item item = new()
//{
//    Id = Guid.NewGuid(),
//    Name = "Shure SM7b",
//    Description = "Microphone",
//    InStock = 5,
//    Price = 999,
//    Warehouses = new WarehouseManagementSystem.Warehouse[]
//    {
//        new () { Id = Guid.NewGuid(), Location = "Sweden" }
//    }
//};

//Order order = new()
//{
//    Id = Guid.NewGuid(),
//    Customer = filip,
//    ShippingProvider = shippingProvider,
//    LineItems = new LineItem[]
//    {
//        new()
//        {
//            Id = Guid.NewGuid(),
//            Item = item,
//            Quantity = 1
//        }
//    }
//};

//using var context = new WarehouseContext();
//context.Database.Migrate();

//context.Orders.Add(order);
//context.SaveChanges();
