using Microsoft.AspNetCore.Mvc;

namespace SemWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ErrorController : ControllerBase
    {
        [HttpGet]
        [Route("/error")]
        public IActionResult Error()
        {
            return Problem(statusCode: 500, title: "Bir hata oluştu.");
        }
    }
}