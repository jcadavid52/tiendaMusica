using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectAdaPruebaTecnica.ViewModel
{
    public class ViewModelUserAutentication
    {
        [Required(ErrorMessage = "El Usuario es obligatorio")]
        public string UsuarioAcceso { get; set; }
        
        [Required(ErrorMessage = "La clave es obligatoria")]
        public string Clave { get; set; }
    
    }
}