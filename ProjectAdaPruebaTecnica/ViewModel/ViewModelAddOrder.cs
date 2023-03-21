using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectAdaPruebaTecnica.ViewModel
{
    public class ViewModelAddOrder
    {
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public int IdProducto { get; set; }
    }
}