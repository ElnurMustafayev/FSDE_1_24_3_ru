using mongo;
using MongoDB.Bson;
using MongoDB.Driver;

const string ConnectionString = "mongodb://localhost:27018/";

var client = new MongoClient(ConnectionString);

var database = client.GetDatabase("products_db");
var collection = database.GetCollection<Product>("items");

// await collection.InsertOneAsync(new Product
// {
//     Name = "Iphone",
//     Price = 1000,
//     InStock = true
// });

// await collection.InsertOneAsync(new Product
// {
//     Name = "TV",
//     Price = 300,
// });

// var filter = FilterDefinition<Product>.Empty;
var filter = Builders<Product>.Filter
    .Gte(p => p.Price, 100);
    //.Eq(p => p.Name, "Iphone");

var itemsCursor = await collection.FindAsync(filter);
var items = await itemsCursor.ToListAsync();

foreach (var item in items)
{
    System.Console.WriteLine(item);
}




// var database = client.GetDatabase("temp_db");
// var collection = database.GetCollection<BsonDocument>("items");

// await collection.InsertOneAsync(new
// {
//     name = "Test",
//     flag = true,
//     tags = new string[] { "one", "two", "three" }
// }.ToBsonDocument());



// var filter = Builders<BsonDocument>.Filter
//     .Eq(doc => doc["name"], "Test");

// var productsCursor = await collection.FindAsync(filter);
// var products = await productsCursor.ToListAsync();

// foreach (var product in products)
// {
//     //product.Cast<Product>();
//     System.Console.WriteLine(product);
// }