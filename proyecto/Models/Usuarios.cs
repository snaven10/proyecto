using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
    [Table("Usuarios")]
    public partial class Usuarios
    {
        [Key]
        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "Escriba el nombre de usuario.")]
        [MinLength(5,ErrorMessage = "Escriba al menos 5 caracteres")]
        [MaxLength(50,ErrorMessage = "Escriba un maximo de 50 caracteres")]
        public string Nombre { get; set; }

        public string Sal { get; set; }

        [Required(ErrorMessage = "Escriba el password.")]
        [MinLength(5, ErrorMessage = "Escriba al menos 5 caracteres")]
        [MaxLength(50, ErrorMessage = "Escriba un maximo de 50 caracteres")]
        public string Clave { get; set; }
    }
}
