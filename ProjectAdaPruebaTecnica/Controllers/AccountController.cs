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
    public class AccountController : Controller
    {
       protected static LogicUser oLogicUser = new LogicUser();
       protected static Usuario user = new Usuario();
        // GET: Account
        public ActionResult AutenticationView()
        {
            ViewBag.Mensaje = "";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AutenticationAction(ViewModelUserAutentication model)
        {
            

            if (!ModelState.IsValid)
            {
                return View("AutenticationView", model);
            }

            user.UsuarioAcceso = model.UsuarioAcceso;
            user.Clave = model.Clave;

            var userValidate = await oLogicUser.AutenticationUser(user);

            if (userValidate == null)
            {
                ViewBag.Mensaje = "Usuario o clave inválida";
                return View("AutenticationView");

            }

            Session["IdUsuario"] = userValidate.IdUsuario;
            Session["Nombre"] = userValidate.Nombre;
            Session.Add("IdRol", userValidate.IdRol);

            if (userValidate.IdRol == 1)
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Store");


        }

        public ActionResult RegisterView()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> RegisterUser(ViewModelRegisterUser model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { respuesta = 0 });
            }

            if (model.Clave1 != model.Clave2)
            {
                return Json(new { respuesta = 1 });
            }

            user.Nombre = model.Nombre;
            user.Apellido = model.Apellido;
            user.Direccion = model.Direccion;
            user.Telefono = model.Telefono;
            user.UsuarioAcceso = model.UsuarioAcceso;
            user.Identificacion = model.Identificacion;
            user.Clave = model.Clave1;

            var validateExistUser = await oLogicUser.ValidateExistUser(user);

            if (validateExistUser != null)
            {
                return Json(new { respuesta = 2 });
            }

            var registerUser = await oLogicUser.RegisterUser(user);

            if (!registerUser)
            {
                return Json(new { respuesta = 3 });
            }

            return Json(new { respuesta = 4 });
        }

        [SessionValidate]
        public ActionResult SessionClose()
        {
            Session["IdUsuario"] = null;

            return RedirectToAction("AutenticationView", "Account");
        }
    }
}