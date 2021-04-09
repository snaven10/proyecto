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
        public string Nombre { get; set; }
        public int Actividad { get; set; }
    }
}
