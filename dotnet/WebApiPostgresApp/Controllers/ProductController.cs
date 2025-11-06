using Dapper;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using WebApiPostgresApp.Entities;

namespace WebApiPostgresApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<Product>> GetProductAsync(int id)
    {
        var connectionString = Environment.GetEnvironmentVariable("POSTGRES_CONN");

        ArgumentNullException.ThrowIfNullOrWhiteSpace(connectionString);

        using var connection = new NpgsqlConnection(connectionString);

        var product = await connection.QueryFirstOrDefaultAsync<Product>("select * from Products where id = @id", new { id });

        if (product is null)
        {
            return base.NotFound();
        }

        return base.Ok(product);
    }
}