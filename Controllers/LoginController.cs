using Microsoft.AspNetCore.Mvc;

namespace Hr_Management.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
