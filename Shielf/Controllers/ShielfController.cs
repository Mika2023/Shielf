using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
namespace Shielf.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShielfController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
