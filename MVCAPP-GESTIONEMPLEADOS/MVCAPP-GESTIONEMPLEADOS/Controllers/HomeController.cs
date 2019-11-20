using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAPP_GESTIONEMPLEADOS.Models;

namespace MVCAPP_GESTIONEMPLEADOS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult Login(Acceso user)
        {
            using (GestionEmpleadosDBEntities db = new GestionEmpleadosDBEntities())
            {

                var userDetail = db.Acceso.Where(x => x.Login == user.Login && x.Pass == user.Pass).FirstOrDefault();
                if (userDetail == null)
                {
                    user.LoginErrorMessage = "Usuario o Contraseña Incorrecta";
                    user.Estado = 0;
                    db.SaveChanges();
                    return View("Index", user);
                }
                else
                {

                    userDetail.Fecha_Ultima_Conexion = DateTime.Now;
                    userDetail.Estado = 1;
                    Session["userID"] = user.Id;
                    Session["userName"] = user.Login;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Empleado");


                }

            }
        }
        public ActionResult LogOut()
        {

            int userId = (int)Session["userID"];
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}