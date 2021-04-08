using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models.ViewModel
{
    public class UsuariosVM
    {
        [Required(ErrorMessage = "Escriba su Usuario.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Escriba su password.")]
        public string Clave { get; set; }
    }
}
