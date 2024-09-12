using Microsoft.AspNetCore.Mvc;

namespace odevproject.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GirisYap() 
        {
            return View();
        }
    }
}
