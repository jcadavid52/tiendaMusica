using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectAdaPruebaTecnica.ViewModel
{
    public class ViewModelUpdateProductApi
    {
        [Required]
        public int IdProducto { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Caracteristica { get; set; }
        [Required]
        public int CantidadDisponible { get; set; }
        [Required]
        public decimal Precio { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public string RutaImagen { get; set; }
    }
}