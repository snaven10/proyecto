using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models.ViewModel
{
    public class UsuariosCLLVM
    {
        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "Escriba su Usuario.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Escriba su password.")]
        public string Rol { get; set; }
    }
}
