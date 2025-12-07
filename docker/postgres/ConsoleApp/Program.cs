using ConsoleApp.Models;
using Dapper;
using Npgsql;

var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

ArgumentNullException.ThrowIfNullOrWhiteSpace(connectionString);

using var connection = new NpgsqlConnection(connectionString);

var users = await connection.QueryAsync<User>("select * from Users");

foreach (var user in users)
{
    System.Console.WriteLine(user);
}