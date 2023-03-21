using ProjectAdaPruebaTecnica.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ProjectAdaPruebaTecnica.Logica
{
    public class LogicCar
    {
        public async Task<int> AmountCar(int iduser)
        {
            using (BD_ADA_SAEntities bd = new BD_ADA_SAEntities())
            {
                try
                {
                    var lstOrder = await bd.Pedido.Where(p => p.IdUsuario == iduser && p.Estado == false).ToListAsync();

                    var amount = lstOrder.Count();

                    return amount;
                }
                catch (Exception ex)
                {
                    return -1;
                }
            }
        }
        public async Task<List<Pedido>> ListCar(int id)
        {
            using (BD_ADA_SAEntities bd = new BD_ADA_SAEntities())
            {
                try
                {
                    return await bd.Pedido.Include("Producto").Where(p => p.IdUsuario == id && p.Estado == false).ToListAsync();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        

    }
}