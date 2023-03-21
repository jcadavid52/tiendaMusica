using System;
using System.Collections.Generic;

#nullable disable

namespace ApiAdaProject.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Caracteristica { get; set; }
        public int CantidadDisponible { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }
        public string RutaImagen { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
