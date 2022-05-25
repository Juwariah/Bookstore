using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TodoItems.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        [HttpGet(Name = "GetPerson")]
        public string Get()
        {
            return "Hello you";
        }
    }
}
