namespace WebApiApp.Models;

public class Product
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required double Price { get; set; }
    public int? Count { get; set; }
}