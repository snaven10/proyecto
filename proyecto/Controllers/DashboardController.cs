using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using proyecto.Models;
using proyecto.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Controllers
{
    [Authorize(Roles = "Supervisor")]
    public class DashboardController : Controller
    {
        readonly ProyectoCTX ctx;

        public DashboardController(ProyectoCTX _ctx)
        {
            ctx = _ctx;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> TotalLlamadas()
        {
            var result = new List<Actividades>();
            result = (
                from ac in ctx.Actividades
                select new Actividades
                {
                    IdActividad = ac.IdActividad
                }
            ).ToList();
            return Ok(new { Total = result.Count() });
        }
        public async Task<IActionResult> TotalLlamadasRes()
        {
            var result = new List<Actividades>();
            result = (
                from ac in ctx.Actividades.Where(x=>x.Resolvio == "Resolvio")
                select new Actividades
                {
                    IdActividad = ac.IdActividad
                }
            ).ToList();
            return Ok(new { Total = result.Count() });
        }
        public async Task<IActionResult> TotalLlamadasNoRes()
        {
            var result = new List<Actividades>();
            result = (
                from ac in ctx.Actividades.Where(x => x.Resolvio == "No Resolvio")
                select new Actividades
                {
                    IdActividad = ac.IdActividad
                }
            ).ToList();
            return Ok(new { Total = result.Count() });
        }
        public async Task<IActionResult> AgentesMayores()
        {
            return Ok(new { Total = "No terminado" });
        }
        public async Task<IActionResult> AgentesMenores()
        {
            return Ok(new { Total = "No terminado" });
        }
    }
}
