using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Controllers
{
    [Authorize(Roles = "Agente")]
    public class ActividadController : Controller
    {
        readonly ProyectoCTX ctx;

        public ActividadController(ProyectoCTX _ctx)
        {
            ctx = _ctx;
        }
        public async Task<IActionResult> Index()
        {
            return View(await ctx.Actividades.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [BindProperty]
        public Actividades Actividads { get; set; }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection collection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.SelectMany(x => x.Value.Errors.Select(y => y.ErrorMessage)).ToList());
            }
            else
            {
                ctx.Actividades.Add(Actividads);
                await ctx.SaveChangesAsync();
                return Created($"/Actividad/{Actividads.IdActividad}", Actividads);
            }
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actividad = await ctx.Actividades.FindAsync(id);
            if (actividad == null)
            {
                return NotFound();
            }
            return View(actividad);
        }
        [BindProperty]
        public Actividades Actividade { get; set; }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormCollection collection)
        {
            if (id != Actividade.IdActividad)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.SelectMany(x => x.Value.Errors.Select(y => y.ErrorMessage)).ToList());
            }
            else
            {
                var actividad = ctx.Actividades.First(a => a.IdActividad == Actividade.IdActividad);
                actividad.Duracion_llamada = Actividade.Duracion_llamada;
                actividad.Descripcion = Actividade.Descripcion;
                actividad.Tipo = Actividade.Tipo;
                actividad.Resolvio = Actividade.Resolvio;
                ctx.SaveChanges();
                return Created($"/Actividad/{Actividads.IdActividad}", actividad);
            }
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actividad = await ctx.Actividades
                .FirstOrDefaultAsync(m => m.IdActividad == id);
            if (actividad == null)
            {
                return NotFound();
            }

            return View(actividad);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actividad = await ctx.Actividades.FindAsync(id);
            ctx.Actividades.Remove(actividad);
            await ctx.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
