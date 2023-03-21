using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectAdaPruebaTecnica.ViewModel
{
    public class ViewModelDetailProduct
    {
        public string Nombre { get; set; }
        public string Caracteristica { get; set; }
        public int CantidadDisponible { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }
        public string RutaImagen { get; set; }
    }
}