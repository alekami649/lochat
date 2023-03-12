using Microsoft.AspNetCore.Mvc;
using Lochat.Shared;

namespace Lochat.Protocol.Controllers;

[ApiController]
public class KeyController : Controller
{
    [HttpGet]
    [Route("keys/get")]
    public IActionResult GetKey(Profile profile)
    {
        var rsa = RSA();
    }
}
