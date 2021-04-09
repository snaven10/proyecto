using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
    public partial class Actividades
    {
        [Key, Column("Id")]
        public int IdActividad { get; set; }
        [StringLength(20)]
        [Required(ErrorMessage = "Escriba la duracion de la llamada")]
        public string Duracion_llamada { get; set; }
        [Required(ErrorMessage = "Escriba una descripcion")]
        [StringLength(50)]
        public string Descripcion { get; set; }
        [StringLength(150)]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "Seleccione un Tipo")]
        [StringLength(20)]
        public string Tipo { get; set; }
        [Required(ErrorMessage = "Seleccione si fue resuelto el problema")]
        [StringLength(20)]
        public string Resolvio { get; set; }
        public string IdUsuario { get; set; }
    }
}
