namespace mongo;

using MongoDB.Bson;

public class Product
{
    public ObjectId Id { get; set; }
    public required string Name { get; set; }
    public required double Price { get; set; }
    public bool? InStock { get; set; }

    public override string ToString()
    {
        return $"{Id}: {Name} {Price}. In stock: {InStock}";
    }
}