using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyecto.Helper;
using proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Controllers
{
    [Authorize(Roles = "Supervisor")]
    public class UsuarioController : Controller
    {
        readonly ProyectoCTX ctx;

        public UsuarioController(ProyectoCTX _ctx)
        {
            ctx = _ctx;
        }
        // GET: UsuarioController
        public async Task<IActionResult> Index()
        {
            var result = new List<Usuarios>();
            result = (
                from au in ctx.Usuarios
                from aur in ctx.UsuarioRol.Where(x => x.IdUsuario == au.IdUsuario)
                from ar in ctx.Roles.Where(x => x.IdRol == aur.IdRol && x.Descripcion == "Agente")
                select new Usuarios
                {
                    IdUsuario = au.IdUsuario,
                    Nombre = au.Nombre,
                }
            ).ToList();
            return View(result);
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [BindProperty]
        public Usuarios Usuario { get; set; }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create(IFormCollection collection)
        {
            var result = await ctx.Usuarios.Where(x => x.Nombre == Usuario.Nombre).SingleOrDefaultAsync();
            if (result != null)
            {
                return BadRequest(new { Message = "El usuario ya existe, seleccione otro." });
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.SelectMany(x => x.Value.Errors.Select(y => y.ErrorMessage)).ToList());
                }
                else
                {
                    var hash = HashHelper.Hash(Usuario.Clave);
                    Usuario.Clave = hash.Password;
                    Usuario.Sal = hash.Salt;
                    ctx.Usuarios.Add(Usuario);
                    await ctx.SaveChangesAsync();
                    var role = ctx.Roles.Where(x => x.Descripcion == "Agente").ToList();
                    ctx.UsuarioRol.Add(new UsuarioRol
                    {
                        IdUsuario = Usuario.IdUsuario,
                        IdRol = role[0].IdRol
                    });
                    await ctx.SaveChangesAsync();
                    return Created($"/Usuarios/{Usuario.IdUsuario}", Usuario);
                }
            }
        }

        // GET: UsuarioController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actividad = await ctx.Usuarios
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (actividad == null)
            {
                return NotFound();
            }

            return View(actividad);
        }

        // POST: UsuarioController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await ctx.Usuarios.FindAsync(id);
            ctx.Usuarios.Remove(usuario);
            await ctx.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
