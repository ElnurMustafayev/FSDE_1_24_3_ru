namespace WebApi2App.Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    [HttpGet]
    public ActionResult SayHelloWorld()
    {
        return base.Ok(Environment.GetEnvironmentVariable("Test"));
    }
}