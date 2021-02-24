using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suscripcion_Encode.Shared
{
    public class Suscriptor
    {
        [Key]
        public int IdSuscriptor { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public int Apellido { get; set; }
        [Required, Phone, MaxLength(8)]
        public string NumeroDocumento { get; set; }
        [Required]
        public int TipoDocumento { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required, Phone]
        public string Telefono { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string NombreUsuario { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
