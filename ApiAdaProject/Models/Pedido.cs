using System;
using System.Collections.Generic;

#nullable disable

namespace ApiAdaProject.Models
{
    public partial class Pedido
    {
        public int IdPedido { get; set; }
        public decimal? ValorParcial { get; set; }
        public bool? Estado { get; set; }
        public int Cantidad { get; set; }
        public int IdProducto { get; set; }
        public int IdUsuario { get; set; }

        public virtual Producto IdProductoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
