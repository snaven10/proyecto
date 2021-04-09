using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyecto.Helper;
using proyecto.Models;
using proyecto.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace proyecto.Controllers
{
    public class LoginController : Controller
    {
        ProyectoCTX ctx;

        public LoginController(ProyectoCTX _ctx)
        {
            ctx = _ctx;
        }
        public IActionResult Index()
        {
            return View();
        }
        [BindProperty]
        public UsuariosVM Usuario {get; set;}
        public async Task<IActionResult> Login()
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(new { Message = "El usuario ya existe, seleccione otro." });
            }
            else 
            {
                var result = await ctx.Usuarios.Include("Roles.Rol").Where(x => x.Nombre == Usuario.Nombre).SingleOrDefaultAsync();
                if(result == null)
                {
                    return NotFound(new { Message = "Usuario no encontrado" });
                }
                else
                {
                    if(HashHelper.CheckHash(Usuario.Clave, result.Clave, result.Sal))
                    {
                        if (result.Roles.Count == 0)
                        {
                            return StatusCode(403, new { Message = "No se le a autorizado el acceso." });
                        }
                        result.Clave = "";
                        result.Sal = "";

                        var userClaims = new List<Claim>()
                        {
                            new Claim(ClaimTypes.NameIdentifier, result.IdUsuario.ToString()),
                            new Claim(ClaimTypes.Name,  result.Nombre),
                            new Claim(ClaimTypes.Email, "frjsamuel@gmail.com"),
                        };
                        var grandmaIdentity = new ClaimsIdentity(userClaims, "User Identity");
                        foreach(var Rol in result.Roles)
                        {
                            grandmaIdentity.AddClaim(new Claim(ClaimTypes.Role, Rol.Rol.Descripcion));
                        }
                        var userPrincipal = new ClaimsPrincipal(new[] { grandmaIdentity });
                        await HttpContext.SignInAsync(userPrincipal);
                        return Ok(result);
                    }
                    else
                    {
                        return StatusCode(403, new { Message = "Usuario o password no valido" });
                    }
                }
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Login");
        }
    }
}
