using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suscripcion_Encode.Shared
{
    public class Suscripcion
    {
        [Key]
        public int IdAsociacion { get; set; }
        public int IdSuscriptor { get; set; }
        [ForeignKey("IdSuscriptor")]
        public virtual Suscriptor Suscriptor { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaFin { get; set; }
        public string MotivoFin { get; set; }
    }
}