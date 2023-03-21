using System;
using System.Collections.Generic;

#nullable disable

namespace ApiAdaProject.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Pedidos = new HashSet<Pedido>();
            Transaccions = new HashSet<Transaccion>();
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string UsuarioAcceso { get; set; }
        public string Identificacion { get; set; }
        public string Clave { get; set; }
        public int IdRol { get; set; }

        public virtual Role IdRolNavigation { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
        public virtual ICollection<Transaccion> Transaccions { get; set; }
    }
}
