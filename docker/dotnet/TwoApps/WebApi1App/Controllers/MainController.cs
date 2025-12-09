namespace WebApi1App.Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class MainController : ControllerBase
{
    private readonly IHttpClientFactory httpClientFactory;
    public MainController(IHttpClientFactory httpClientFactory)
    {
        this.httpClientFactory = httpClientFactory;
    }
    [HttpGet("Key")]
    public async Task<ActionResult> GetKey()
    {
        var httpClient = this.httpClientFactory.CreateClient("KeyWebApi");

        var accessKeyResponseStr = await httpClient.GetStringAsync("/api/Key/Access");
        var secretKeyResponseStr = await httpClient.GetStringAsync("/api/Key/Secret");

        return base.Ok(new
        {
            accessKey = accessKeyResponseStr,
            secretKey = secretKeyResponseStr,
        });
    }
}