using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectAdaPruebaTecnica.ViewModel
{
    public class ViewModelRegisterUser
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public string UsuarioAcceso { get; set; }
        [Required]
        public string Identificacion { get; set; }
        [Required]
        public string Clave1 { get; set; }
        [Required]
        public string Clave2 { get; set; }
    }
}