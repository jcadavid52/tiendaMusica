using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectAdaPruebaTecnica.ViewModel
{
    public class ViewModelListCar
    {
        public int IdPedido { get; set; }
        public Nullable<decimal> ValorParcial { get; set; }
        public Nullable<bool> Estado { get; set; }
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Caracteristica { get; set; }
        public int Cantidad { get; set; }
    }
}