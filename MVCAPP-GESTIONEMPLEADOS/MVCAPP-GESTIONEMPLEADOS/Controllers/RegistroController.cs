using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAPP_GESTIONEMPLEADOS.Models;
using MVCAPP_GESTIONEMPLEADOS.Models.ViewModels;

namespace MVCAPP_GESTIONEMPLEADOS.Controllers
{
    public class RegistroController : Controller
    {
        // GET: CrearEmpleado
        public ActionResult New()
        {
            EmpleadoViewModel modelo = new EmpleadoViewModel();
            GestionEmpleadosDBEntities db = new GestionEmpleadosDBEntities();
            modelo.AfpLista = db.Afp.ToList<Afp>();
            modelo.PrevisionLista = db.Salud.ToList<Salud>();
            modelo.OtrosDescuentosLista = db.Otros_Descuentos.ToList<Otros_Descuentos>();

            return View(modelo);
        }



        [HttpPost]
        public ActionResult New(EmpleadoViewModel model, int rut)
        {

            try
            {

                if (ModelState.IsValid)
                {

                    GestionEmpleadosDBEntities db = new GestionEmpleadosDBEntities();

                    var HaberesQ = (from hab in db.Haberes
                                    join emp in db.Empleado on hab.rut_empleado equals emp.rut
                                    where emp.rut == rut
                                    select hab).FirstOrDefault();
                    //-------------------------------------------//

                    var DescuentoQ = (from des in db.Descuento
                                      join emp in db.Empleado on des.rut_empleado equals emp.rut
                                      where emp.rut == rut
                                      select des).FirstOrDefault();

                    var Haberes = new Haberes();
                    var Descuento = new Descuento();
                    var oTabla = new Empleado();

                    oTabla.rut = model.rut;
                    oTabla.dv = model.dv;
                    oTabla.nombre = model.nombre;
                    oTabla.apaterno = model.apaterno;
                    oTabla.amaterno = model.amaterno;
                    oTabla.direccion = model.direccion;
                    oTabla.email = model.email;
                    oTabla.genero = model.genero;
                    oTabla.fecha_nacimiento = model.fecha_nacimiento;
                    oTabla.annos_experiencia = model.annos_experiencia;
                    oTabla.fecha_contrato = model.fecha_contrato;
                    oTabla.telefono = model.telefono;
                    oTabla.nombre_profesion = model.nombre_profesion;
                    oTabla.afp_id = model.afp_id;
                    oTabla.salud_id = model.salud_id;
                    if (model.numero_cargas == null) { model.numero_cargas = 0; oTabla.numero_cargas = 0; }
                    else { oTabla.numero_cargas = model.numero_cargas; }
                    if (model.sueldo_base <= 315841)
                    {
                        oTabla.asignacion_id = 1;

                    }
                    else if (model.sueldo_base <= 461320)
                    {
                        oTabla.asignacion_id = 2;

                    }
                    else if (model.sueldo_base <= 719502)
                    {
                        oTabla.asignacion_id = 3;

                    }
                    else
                    {
                        oTabla.asignacion_id = 4;

                    }
                    oTabla.sueldo_base = model.sueldo_base;
                    oTabla.desc_id = model.desc_id;
                    DateTime annos = Convert.ToDateTime(model.fecha_contrato);
                    int trabajados = DateTime.Today.AddTicks(-annos.Ticks).Year - 1;

                    if (trabajados == 0) { model.antiguedad_id = 10; }
                    else if (trabajados <= 2) { model.antiguedad_id = 20; }
                    else if (trabajados <= 4) { model.antiguedad_id = 30; }
                    else if (trabajados <= 6) { model.antiguedad_id = 40; }
                    else if (trabajados <= 8) { model.antiguedad_id = 50; }
                    else if (trabajados <= 10) { model.antiguedad_id = 60; }
                    else if (trabajados <= 12) { model.antiguedad_id = 70; }
                    else if (trabajados <= 14) { model.antiguedad_id = 80; }
                    else if (trabajados <= 16) { model.antiguedad_id = 90; }
                    else if (trabajados <= 18) { model.antiguedad_id = 100; }
                    else if (trabajados <= 20) { model.antiguedad_id = 110; }
                    else { model.antiguedad_id = 110; }
                    oTabla.antiguedad_id = model.antiguedad_id;
                    
                    Haberes.rut_empleado = model.rut;
                    Descuento.rut_empleado = model.rut;

                    db.Empleado.Add(oTabla);
                    db.Haberes.Add(Haberes);
                    db.Descuento.Add(Descuento);
                    db.SaveChanges();



                    return Redirect("~/Empleado/");
                }

                return Redirect("~/Empleado/");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}