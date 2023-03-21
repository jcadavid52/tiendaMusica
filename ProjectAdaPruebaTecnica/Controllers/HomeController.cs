using Newtonsoft.Json;
using ProjectAdaPruebaTecnica.Logica;
using ProjectAdaPruebaTecnica.Models;
using ProjectAdaPruebaTecnica.Utilities;
using ProjectAdaPruebaTecnica.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProjectAdaPruebaTecnica.Controllers
{
    [SessionValidate]
    [ValidateAdmin]
    public class HomeController : Controller
    {
         protected static LogicTransaction oLogicTransaction = new LogicTransaction();
         public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetTransactions()
        {
            var lstTransaction = await oLogicTransaction.ListTransaction();

            if (lstTransaction == null || lstTransaction.Count <= 0)
            {
                return Json(new { data = false }, JsonRequestBehavior.AllowGet);
            }

            var lstDataTableTransactions = new List<ViewModelDataTableTransactions>();

            foreach (var item in lstTransaction)
            {
                var oViewTransaction = new ViewModelDataTableTransactions();

                oViewTransaction.IdTransaccion = item.IdTransaccion;
                oViewTransaction.FechaCompra = item.FechaCompra;
                oViewTransaction.CantidadComprada = item.CantidadComprada;
                oViewTransaction.ValorCompra = item.ValorCompra;
                oViewTransaction.Nombre = item.Usuario.Nombre;
                oViewTransaction.Apellido = item.Usuario.Apellido;
                oViewTransaction.Telefono = item.Usuario.Telefono;

                lstDataTableTransactions.Add(oViewTransaction);
            }

            return Json(new { data = lstDataTableTransactions },JsonRequestBehavior.AllowGet);
        }

        public ActionResult UsersBuysView()
        {
           

            return View();
        }

        public ActionResult ProductsAvailableView()
        {


            return View();
        }

        [HttpGet]
        public async Task<JsonResult> ProductListApi()
        {
            var httpClient = new HttpClient();

            var responseProducts = await httpClient.GetStringAsync("https://localhost:44359/api/Products");

            var lstProducts = JsonConvert.DeserializeObject<List<Producto>>(responseProducts);

            return Json(new { data = lstProducts }, JsonRequestBehavior.AllowGet);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> EditProductApi(ViewModelUpdateProductApi model)
        {
            if (!ModelState.IsValid)
                return Json(new { status = 0 });

            var oHttpClient = new HttpClient();

            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            var response = await oHttpClient.PutAsync("https://localhost:44359/api/Products/" + model.IdProducto,content);

            if (!response.IsSuccessStatusCode)
            {
                return Json(new { status = 1 });
            }

            return Json(new { status = 2 });
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        [HttpGet]
        public async Task<JsonResult> UserBuyListApi()
        {
            var httpClient = new HttpClient();

            var responseUserBuys = await httpClient.GetStringAsync("https://localhost:44359/api/UserBuys");

            var lstUserBuys = JsonConvert.DeserializeObject<List<Usuario>>(responseUserBuys);

            return Json(new { data = lstUserBuys }, JsonRequestBehavior.AllowGet);

        }
    }
}