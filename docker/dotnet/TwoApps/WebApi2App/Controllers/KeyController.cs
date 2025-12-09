namespace WebApi2App.Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class KeyController : ControllerBase
{
    [HttpGet("Access")]
    public ActionResult GetAccessKey()
    {
        return base.Ok("Access KEY");
    }

    [HttpGet("Secret")]
    public ActionResult GetSecretKey()
    {
        return base.Ok("Secret KEY");
    }
}