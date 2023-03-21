using ProjectAdaPruebaTecnica.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ProjectAdaPruebaTecnica.Logica
{
    public class LogicOrder
    {
        public async Task<bool> AddOrder(Pedido model)
        {
            using (BD_ADA_SAEntities bd = new BD_ADA_SAEntities())
            {
                try
                {
                    bd.Pedido.Add(model);
                    await bd.SaveChangesAsync();

                    return true;

                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public async Task<bool> UpdatePartialPrice(int idCarrito, decimal precioProducto, int idUsuario, int cantidad, int idProducto)
        {
            using (BD_ADA_SAEntities bd = new BD_ADA_SAEntities())
            {
                try
                {
                    var car = await bd.Pedido.Where(p => p.IdPedido == idCarrito && p.IdUsuario == idUsuario && p.IdProducto == idProducto).FirstOrDefaultAsync();

                    if (car == null)
                    {
                        return false;
                    }

                    bd.Pedido.Attach(car);
                    car.ValorParcial = cantidad * precioProducto;
                    car.Cantidad = cantidad;
                    car.Estado = false;

                    bd.SaveChanges();

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public async Task<bool> DeletePartialOrder(int id)
        {
            using (BD_ADA_SAEntities bd = new BD_ADA_SAEntities())
            {
                try
                {
                    var orderPartial = await bd.Pedido.Where(p => p.IdPedido == id).FirstOrDefaultAsync();

                    if (orderPartial == null)
                        return false;

                    bd.Pedido.Attach(orderPartial);
                    bd.Pedido.Remove(orderPartial);
                    bd.SaveChanges();

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

        }

        public async Task<decimal?> CalculateTotalPricePartial(int idUser)
        {
            using (BD_ADA_SAEntities bd = new BD_ADA_SAEntities())
            {
                try
                {
                    var total = await bd.Pedido.Where(p => p.IdUsuario == idUser && p.Estado == false).SumAsync(p => p.ValorParcial);

                    return total;
                }
                catch (Exception ex)
                {
                    return 0;
                }
            }
        }

        public async Task<bool> ProcessPayment(int id)
        {
            using (BD_ADA_SAEntities bd = new BD_ADA_SAEntities())
            {

                try
                {
                    await Task.Run(() => bd.SP_ADD_Transaction(id));

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public async Task<bool> GetOrder(int idProducto,int idUsuario)
        {
            using (BD_ADA_SAEntities bd = new BD_ADA_SAEntities())
            {
                try
                {
                    var existOrder = await bd.Pedido.Where(p => p.IdProducto == idProducto && p.IdUsuario == idUsuario).FirstOrDefaultAsync();

                    if(existOrder == null)
                    {
                        return false;
                    }

                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }
               

            }
        }
    }
}