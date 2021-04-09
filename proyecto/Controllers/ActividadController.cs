using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Controllers
{
    [Authorize]
    public class ActividadController : Controller
    {
        readonly ProyectoCTX ctx;

        public ActividadController(ProyectoCTX _ctx)
        {
            ctx = _ctx;
        }
        [Authorize(Roles = "Agente")]
        public async Task<IActionResult> Index()
        {
            return Ok(await ctx.Usuarios.Include("Roles.Rol").ToListAsync());
        }
    }
}
