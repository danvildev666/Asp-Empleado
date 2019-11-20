using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAPP_GESTIONEMPLEADOS.Models;
using MVCAPP_GESTIONEMPLEADOS.Models.ViewModels;

namespace MVCAPP_GESTIONEMPLEADOS.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult Index()
        {
            List<EmpleadoViewModel> list;
            {

                GestionEmpleadosDBEntities db = new GestionEmpleadosDBEntities();

                list = (from d in db.Empleado
                        select new EmpleadoViewModel
                        {

                            IdEmpleado = d.IdEmpleado,
                            rut = d.rut,
                            dv = d.dv,
                            amaterno = d.amaterno,
                            apaterno = d.apaterno,
                            direccion = d.direccion,
                            email = d.email,
                            fecha_nacimiento = d.fecha_nacimiento,
                            genero = d.genero,
                            nombre_profesion = d.nombre_profesion,
                            nombre = d.nombre,
                            annos_experiencia = d.annos_experiencia,
                            telefono = d.telefono


                        }).ToList();



            }
            return View(list);
        }


        [HttpGet]
        public ActionResult Perfil(int rut)
        {

            PerfilViewModel model = new PerfilViewModel();
            GestionEmpleadosDBEntities db = new GestionEmpleadosDBEntities();

            var empleado = (from emp in db.Empleado
                            join af in db.Afp on emp.afp_id equals af.Id
                            where emp.rut == rut
                            select emp).FirstOrDefault();

            var afp = (from emp in db.Empleado
                       join af in db.Afp on emp.afp_id equals af.Id
                       where emp.rut == rut
                       select af).FirstOrDefault();

            var haberes = (from hab in db.Haberes
                           join emp in db.Empleado on hab.rut_empleado equals emp.rut
                           where emp.rut == rut
                           select hab).FirstOrDefault();

            var descuento = (from des in db.Descuento
                             join emp in db.Empleado on des.rut_empleado equals emp.rut
                             where emp.rut == rut
                             select des).FirstOrDefault();

            var otros = (from emp in db.Empleado
                         join otr in db.Otros_Descuentos on emp.desc_id equals otr.id
                         where emp.rut == rut
                         select otr).FirstOrDefault();

            var cargaFam = (from emp in db.Empleado
                            join fam in db.Asignacion_familiar on emp.asignacion_id equals fam.Id
                            where emp.rut == rut
                            select fam).FirstOrDefault();

            var salud = (from emp in db.Empleado
                         join sal in db.Salud on emp.salud_id equals sal.Id
                         where emp.rut == rut
                         select sal).FirstOrDefault();

            var beneficio = (from emp in db.Empleado
                             join ben in db.Beneficio_Antiguedad on emp.antiguedad_id equals ben.Id
                             where emp.rut == rut
                             select ben).FirstOrDefault();



            // if (empleado != null && afp != null && haberes != null && descuento != null && otros != null)
            if (ModelState.IsValid && empleado != null && afp != null && haberes != null && descuento != null && otros != null)
            {
                model.Rut = empleado.rut;

                model.sueldo_basevm = Convert.ToString(empleado.sueldo_base);
                if (cargaFam.tramo == "d") { model.TieneCargavm = "NO"; }
                else if (cargaFam.Id == 5) { model.TieneCargavm = "No Registrado"; }
                else { model.TieneCargavm = "SI"; }

                model.ComisionAFP = afp.comision;
                model.monto_familiarvm = haberes.monto_familiar;
                model.calculoHoraExtra = haberes.hora_extra;
                model.comisionvm = haberes.comision;
                model.bonovm = haberes.bono;
                model.colacionvm = haberes.colacion;
                model.movilizacionvm = haberes.movilizacion;
                //-------------------------------------------//

                model.NombreAfp = afp.nombre;
                model.descuento_afpvm = descuento.descuento_afp;
                model.tiposaludvm = salud.tipo_salud;
                model.descuento_saludvm = descuento.descuento_salud;
                model.descuento_cesantiavm = descuento.seguro_cesantia;
                model.descuento_segurovidavm = descuento.seguro_vida;
                //-------------------------------------------//
                model.total_haberesvm = haberes.total_haberes;
                model.total_descuentosvm = descuento.total_descuentos;
                model.sueldo_liquidovm = empleado.sueldo_liquido;

                return View(model);
            }
            

            else
            {
                return RedirectToAction("Index", "Empleado");
            }


        }








    }

}