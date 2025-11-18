using WebApiApp.Models;

namespace WebApiApp.Mocks;

public class ProductsMock
{
    public static IEnumerable<Product> Value {
        get {
            return new List<Product>() {
                new Product {
                    Id = 1,
                    Name = "IPhone",
                    Price = 1500,
                    Count = 5,
                },
                new Product {
                    Id = 5,
                    Name = "Test",
                    Price = 132.5,
                    Count = null,
                },
                new Product {
                    Id = 16,
                    Name = "TV",
                    Price = 600,
                    Count = 1,
                }
            };
        }
    }
}