using ProjectAdaPruebaTecnica.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ProjectAdaPruebaTecnica.Logica
{
    public class LogicProduct
    {
        public async Task<List<Producto>> ListProduct()
        {
            using (BD_ADA_SAEntities bd = new BD_ADA_SAEntities())
            {
                try
                {
                    return await bd.Producto.ToListAsync();
                }catch(Exception ex)
                {
                    return null;
                }
            }
        }

        public async Task<Producto> DetailProduct(int id)
        {
            using (BD_ADA_SAEntities bd = new BD_ADA_SAEntities())
            {
                try
                {
                    return await bd.Producto.Where(p => p.IdProducto == id).FirstOrDefaultAsync();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}