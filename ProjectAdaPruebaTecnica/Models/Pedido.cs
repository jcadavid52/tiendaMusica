//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectAdaPruebaTecnica.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pedido
    {
        public int IdPedido { get; set; }
        public Nullable<decimal> ValorParcial { get; set; }
        public Nullable<bool> Estado { get; set; }
        public int Cantidad { get; set; }
        public int IdProducto { get; set; }
        public int IdUsuario { get; set; }
    
        public virtual Producto Producto { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}