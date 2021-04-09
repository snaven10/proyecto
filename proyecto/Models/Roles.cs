using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
    [Table("Roles")]
    public partial class Roles
    {
        [Key, Column("Id")]
        public int IdRol { get; set; }
        public string Descripcion { get; set; }
    }
}
