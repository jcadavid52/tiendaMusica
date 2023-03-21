using ProjectAdaPruebaTecnica.Logica;
using ProjectAdaPruebaTecnica.Models;
using ProjectAdaPruebaTecnica.Utilities;
using ProjectAdaPruebaTecnica.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProjectAdaPruebaTecnica.Controllers
{
    [SessionValidate]
    [ValidateRolUser]
    public class StoreController : Controller
    {
      protected static LogicProduct oLogicProduct = new LogicProduct();
      protected static LogicCar oLogicCar = new LogicCar();
      protected static LogicOrder oLogicOrder = new LogicOrder();

        // GET: Store
        public async Task<ActionResult> Index()
        {
            var lstProducts = await oLogicProduct.ListProduct();

            return View(lstProducts);
        }

        [HttpGet]
        public async Task<JsonResult> AmountCar()
        {
            int id = int.Parse(Session["IdUsuario"].ToString());

            if (id <= 0)
            {
                return Json(new { cantidadCarrito = -1 });
            }

            var amount = await oLogicCar.AmountCar(id);

            if (amount < 0)
            {
                return Json(new { cantidadCarrito = -1 });
            }

            return Json(new { cantidadCarrito = amount }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<JsonResult> DetailProduct(int id)
        {

            if (id <= 0)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }

            var product = await oLogicProduct.DetailProduct(id);

            if (product == null)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }

            var oViewModelProduct = new ViewModelDetailProduct();

            oViewModelProduct.Nombre = product.Nombre;
            oViewModelProduct.CantidadDisponible = product.CantidadDisponible;
            oViewModelProduct.Descripcion = product.Descripcion;
            oViewModelProduct.RutaImagen = product.RutaImagen;
            oViewModelProduct.Precio = product.Precio;
            oViewModelProduct.Caracteristica = product.Caracteristica;

            return Json(oViewModelProduct, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddOrder(ViewModelAddOrder model)
        {

            if (!ModelState.IsValid)
            {
                return Json(new { status = 0 });
            }

            

            var Product = await oLogicProduct.DetailProduct(model.IdProducto);

            int idUsuario = int.Parse(Session["IdUsuario"].ToString());

            if (Product == null)
            {
                return Json(new { status = 1 });
            }


            if (model.Cantidad > Product.CantidadDisponible)
            {
                return Json(new { status = 2 });
            }

            if (model.Cantidad <= 0)
            {
                return Json(new { status = 4 });
            }

            var orderExist = await oLogicOrder.GetOrder(model.IdProducto, idUsuario);

            if (orderExist)
            {
                return Json(new { status = 5 });
            }
          
            var Order = new Pedido();

            Order.Cantidad = model.Cantidad;
            Order.IdProducto = model.IdProducto;
            Order.ValorParcial = model.Cantidad * Product.Precio;
            Order.IdUsuario = idUsuario;
            Order.Estado = false;

            var OrderRegister = await oLogicOrder.AddOrder(Order);

            if (!OrderRegister)
            {
                return Json(new { status = 3 });
            }

            return Json(new { status = 6 });

        }

        [HttpGet]
        public ActionResult ListCarView()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> ListCar()
        {
            int id = int.Parse(Session["IdUsuario"].ToString());

            var lstCar = await oLogicCar.ListCar(id);

            if (lstCar == null && lstCar.Count == 0)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }

            var lstViewModelCar = new List<ViewModelListCar>();

            foreach (var item in lstCar)
            {
                var oViewModelCar = new ViewModelListCar();

                oViewModelCar.IdPedido = item.IdPedido;
                oViewModelCar.ValorParcial = item.ValorParcial;
                oViewModelCar.Estado = item.Estado;
                oViewModelCar.IdProducto = item.IdProducto;
                oViewModelCar.Cantidad = item.Cantidad;
                oViewModelCar.Nombre = item.Producto.Nombre;
                oViewModelCar.Caracteristica = item.Producto.Caracteristica;

                lstViewModelCar.Add(oViewModelCar);
            }

            return Json(lstViewModelCar, JsonRequestBehavior.AllowGet);



        }

        [HttpPost]
        public async Task<JsonResult> UpdatePartialPrice(int idProducto,int cantidad, int idPedido)
        {
            if(idProducto <= 0)
                return Json(new { response = false });

            if (cantidad <= 0)
                return Json(new { response = false });

            if (idPedido <= 0)
                return Json(new { response = false });

            int id = int.Parse(Session["IdUsuario"].ToString());

            var GetProduct = await oLogicProduct.DetailProduct(idProducto);

            if (GetProduct == null)
            {
                return Json(new { response = false });
            }

            if (GetProduct.CantidadDisponible < cantidad )
            {
                return Json(new { response = 0 });
            }


            var updateOder = await oLogicOrder.UpdatePartialPrice(idPedido, GetProduct.Precio, id,cantidad,idProducto);

            if(updateOder == false)
            {
                return Json(new { response = false });
            }

            return Json(new { response = true });
        }

        [HttpPost]
        public async Task<JsonResult> DeletePartialOrder(int id)
        {
            if (id <= 0)
                return Json(new { response = false });

            var OrderDelete = await oLogicOrder.DeletePartialOrder(id);

            if (!OrderDelete)
            {
                return Json(new { response = false });
            }

            return Json(new { response = true });
        }

        [HttpGet]
        public async Task<JsonResult> CalculateTotalPricePartial()
        {
            int id = int.Parse(Session["IdUsuario"].ToString());

            var priceTotal = await oLogicOrder.CalculateTotalPricePartial(id);

            if (priceTotal == null)
                return Json(0, JsonRequestBehavior.AllowGet);

            return Json(priceTotal, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ProcessPayment()
        {

            int id = int.Parse(Session["IdUsuario"].ToString());

            var ExitProcess = await oLogicOrder.ProcessPayment(id);

            if (!ExitProcess)
            {
                return Json(new { exito = false });
            }

            return Json(new { exito = true });
        }


    }
}