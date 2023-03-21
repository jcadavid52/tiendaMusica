using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectAdaPruebaTecnica.ViewModel
{
    public class ViewModelDataTableTransactions
    {
        public int IdTransaccion { get; set; }
        public System.DateTime FechaCompra { get; set; }
        public int CantidadComprada { get; set; }
        public int ValorCompra { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
    }
}