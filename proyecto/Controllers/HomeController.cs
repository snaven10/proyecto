using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyecto.Helper;
using proyecto.Models;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        ProyectoCTX ctx;

        public HomeController(ProyectoCTX _ctx)
        {
            ctx = _ctx;
        }

        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> Registro() 
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
