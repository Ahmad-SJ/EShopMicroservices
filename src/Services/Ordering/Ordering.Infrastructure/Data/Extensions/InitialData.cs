namespace Ordering.Infrastructure.Data.Extensions;

internal class InitialData
{
    public static IEnumerable<Customer> Customers =>
    new List<Customer>
    {
        Customer.Create(CustomerId.Of(new Guid("eaf0e595-0cc7-474b-ba4b-d3a0ceaff8e0")), "mehmet", "mehmet@gmail.com"),
        Customer.Create(CustomerId.Of(new Guid("d205715e-2325-469c-8fe4-a21033da1fbb")), "john", "john@gmail.com"),
    };

    public static IEnumerable<Product> Products =>
    new List<Product>
    {
        Product.Create(ProductId.Of(new Guid("b94fba6d-e6fd-46cd-97e2-d507242f6fb3")), "IPhone X", 500),
        Product.Create(ProductId.Of(new Guid("d3df7b98-788e-4c72-9cd8-9bc33ddae4b3")), "Samsung 10", 400),
        Product.Create(ProductId.Of(new Guid("6ef13920-c039-437d-97f1-202c7b5c2e28")), "Huawei Plus", 650),
        Product.Create(ProductId.Of(new Guid("a4e109d0-108e-4433-9005-80cb0459474a")), "Xiaomi Mi", 450),
    };

    public static IEnumerable<Order> OrdersWithItems
    {
        get
        {
            var address1 = Address.Of("mehmet", "ozkaya", "mehmet@gmail.com", "Bahcelievler No:4", "Turkey", "Istanbul", "38050");
            var address2 = Address.Of("john", "doe", "john@gmail.com", "Broadway No:1", "England", "Nottingham", "08050");

            var payment1 = Payment.Of("mehmet", "9999999997777777", "12/28", "355", 1);
            var payment2 = Payment.Of("john", "5555566666644441", "06/30", "222", 2);

            var order1 = Order.Create(
                OrderId.Of(Guid.NewGuid()),
                CustomerId.Of(new Guid("eaf0e595-0cc7-474b-ba4b-d3a0ceaff8e0")),
                OrderName.Of("ORD_1"),
                shippingAddress: address1,
                billingAddress: address1,
                payment1);

            order1.Add(ProductId.Of(new Guid("b94fba6d-e6fd-46cd-97e2-d507242f6fb3")), 2, 500);
            order1.Add(ProductId.Of(new Guid("d3df7b98-788e-4c72-9cd8-9bc33ddae4b3")), 1, 400);

            var order2 = Order.Create(
                OrderId.Of(Guid.NewGuid()),
                CustomerId.Of(new Guid("d205715e-2325-469c-8fe4-a21033da1fbb")),
                OrderName.Of("ORD_2"),
                shippingAddress: address2,
                billingAddress: address2,
                payment2);

            order2.Add(ProductId.Of(new Guid("6ef13920-c039-437d-97f1-202c7b5c2e28")), 1, 650);
            order2.Add(ProductId.Of(new Guid("a4e109d0-108e-4433-9005-80cb0459474a")), 2, 450);

            return new List<Order> { order1, order2 };
        }
    }
    
}
