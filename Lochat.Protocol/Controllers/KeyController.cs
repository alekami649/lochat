using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Lochat.Shared;
using Lochat.Console;
using System.Security.Cryptography;

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
