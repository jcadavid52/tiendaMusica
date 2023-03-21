using ProjectAdaPruebaTecnica.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ProjectAdaPruebaTecnica.Logica
{
    public class LogicTransaction
    {
        public async Task<List<Transaccion>> ListTransaction()
        {
            using (BD_ADA_SAEntities bd = new BD_ADA_SAEntities())
            {
                try
                {
                    return await bd.Transaccion.Include("Usuario").ToListAsync();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}