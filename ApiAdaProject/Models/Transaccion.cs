using System;
using System.Collections.Generic;

#nullable disable

namespace ApiAdaProject.Models
{
    public partial class Transaccion
    {
        public int IdTransaccion { get; set; }
        public DateTime FechaCompra { get; set; }
        public int CantidadComprada { get; set; }
        public int ValorCompra { get; set; }
        public int IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
