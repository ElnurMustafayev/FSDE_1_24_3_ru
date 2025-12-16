using System.Text.Json;
using StackExchange.Redis;

var connection = await ConnectionMultiplexer.ConnectAsync("localhost:6380");

var database = connection.GetDatabase(0);

await database.StringSetAsync("test1", JsonSerializer.Serialize(new { name = "secret" }), TimeSpan.FromSeconds(10));

var value = await database.StringGetAsync("test1");

System.Console.WriteLine(value);

/*

product:100 | {json of product with id 100}

*/