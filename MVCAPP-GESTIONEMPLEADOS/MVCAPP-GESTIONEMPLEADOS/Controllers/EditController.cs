using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAPP_GESTIONEMPLEADOS.Models;
using MVCAPP_GESTIONEMPLEADOS.Models.ViewModels;
using MVCAPP_GESTIONEMPLEADOS.Programacion;


namespace MVCAPP_GESTIONEMPLEADOS.Controllers
{
    public class EditController : Controller
    {
        // GET: Edit


        [HttpGet]
        public ActionResult Perfil(int rut)
        {
            GestionEmpleadosDBEntities db = new GestionEmpleadosDBEntities();
            PerfilViewModel model = new PerfilViewModel();
            var empleado = (from emp in db.Empleado
                            join af in db.Afp on emp.afp_id equals af.Id
                            where emp.rut == rut
                            select emp).FirstOrDefault();
            //-------------------------------------------//
            var afp = (from emp in db.Empleado
                       join af in db.Afp on emp.afp_id equals af.Id
                       where emp.rut == rut
                       select af).FirstOrDefault();
            //-------------------------------------------//
            var haberes = (from hab in db.Haberes
                           join emp in db.Empleado on hab.rut_empleado equals emp.rut
                           where emp.rut == rut
                           select hab).FirstOrDefault();
            //-------------------------------------------//
            var descuento = (from des in db.Descuento
                             join emp in db.Empleado on des.rut_empleado equals emp.rut
                             where emp.rut == rut
                             select des).FirstOrDefault();
            //-------------------------------------------//
            var otros = (from emp in db.Empleado
                         join otr in db.Otros_Descuentos on emp.desc_id equals otr.id
                         where emp.rut == rut
                         select otr).FirstOrDefault();
            //-------------------------------------------//
            var cargaFam = (from emp in db.Empleado
                            join fam in db.Asignacion_familiar on emp.asignacion_id equals fam.Id
                            where emp.rut == rut
                            select fam).FirstOrDefault();
            //-------------------------------------------//
            var salud = (from emp in db.Empleado
                         join sal in db.Salud on emp.salud_id equals sal.Id
                         where emp.rut == rut
                         select sal).FirstOrDefault();
            //-------------------------------------------//
            var beneficio = (from emp in db.Empleado
                             join ben in db.Beneficio_Antiguedad on emp.antiguedad_id equals ben.Id
                             where emp.rut == rut
                             select ben).FirstOrDefault();

            if (ModelState.IsValid && empleado != null && afp != null && haberes != null && descuento != null && otros != null)
            {

                model.AfpLista = db.Afp.ToList<Afp>();
                model.PrevisionLista = db.Salud.ToList<Salud>();


                //-------------------------------------------//


                model.Rut = empleado.rut;
                model.sueldo_basevm = Convert.ToString(empleado.sueldo_base);
                //-------------------------------------------//
                if (empleado.asignacion_id < 4) { model.TieneCargavm = "SI"; }
                else if (empleado.asignacion_id == 5) { model.TieneCargavm = "No Registrado"; }
                else if (empleado.asignacion_id == 4) { model.TieneCargavm = "NO"; }
                else { model.TieneCargavm = "SI"; }
                //-------------------------------------------//

                //-------------------------------------------//
                model.monto_familiarvm = haberes.monto_familiar;
                model.calculoHoraExtra = haberes.hora_extra;
                model.comisionvm = haberes.comision;
                model.bonovm = (beneficio.porcentaje_antiguedad * empleado.sueldo_base) / 100;
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
                //-------------------------------------------//
                return View(model);
            }
            else
            {
                Programacion.AutoCompletar Metodo = new AutoCompletar();
                Metodo.IA(model, rut);
                return RedirectToAction("Perfil", "Edit", new { rut });
            }
        }


        [HttpPost]
        public ActionResult Perfil(PerfilViewModel model, int rut)
        {

            try
            {

                if (ModelState.IsValid)
                {
                    GestionEmpleadosDBEntities db = new GestionEmpleadosDBEntities();


                    var empleado = (from emp in db.Empleado
                                    join af in db.Afp on emp.afp_id equals af.Id
                                    where emp.rut == rut
                                    select emp).FirstOrDefault();
                    //-------------------------------------------//
                    var afp = (from emp in db.Empleado
                               join af in db.Afp on emp.afp_id equals af.Id
                               where emp.rut == rut
                               select af).FirstOrDefault();
                    //-------------------------------------------//
                    var haberes = (from hab in db.Haberes
                                   join emp in db.Empleado on hab.rut_empleado equals emp.rut
                                   where emp.rut == rut
                                   select hab).FirstOrDefault();
                    //-------------------------------------------//
                    var descuento = (from des in db.Descuento
                                     join emp in db.Empleado on des.rut_empleado equals emp.rut
                                     where emp.rut == rut
                                     select des).FirstOrDefault();
                    //-------------------------------------------//
                    var otros = (from emp in db.Empleado
                                 join otr in db.Otros_Descuentos on emp.desc_id equals otr.id
                                 where emp.rut == rut
                                 select otr).FirstOrDefault();
                    //-------------------------------------------//
                    var cargaFam = (from emp in db.Empleado
                                    join fam in db.Asignacion_familiar on emp.asignacion_id equals fam.Id
                                    where emp.rut == rut
                                    select fam).FirstOrDefault();
                    //-------------------------------------------//
                    var salud = (from emp in db.Empleado
                                 join sal in db.Salud on emp.salud_id equals sal.Id
                                 where emp.rut == rut
                                 select sal).FirstOrDefault();
                    //-------------------------------------------//
                    var beneficio = (from emp in db.Empleado
                                     join ben in db.Beneficio_Antiguedad on emp.antiguedad_id equals ben.Id
                                     where emp.rut == rut
                                     select ben).FirstOrDefault();

                    //-------------------------------------------//
                    empleado.sueldo_base = Convert.ToDouble(model.sueldo_basevm);

                    if (empleado.sueldo_base == null)
                    {
                        empleado.sueldo_base = 0;

                    }

                    else if (haberes.sueldo_base != empleado.sueldo_base || haberes.Empleado == null)
                    {
                        haberes.sueldo_base = empleado.sueldo_base;

                    }

                    if (haberes.sueldo_base <= 315841)
                    {
                        empleado.asignacion_id = 1;
                        haberes.monto_familiar = empleado.numero_cargas * cargaFam.valor;
                        model.monto_familiarvm = empleado.numero_cargas * cargaFam.valor;
                    }
                    else if (haberes.sueldo_base <= 461320)
                    {
                        empleado.asignacion_id = 2;
                        haberes.monto_familiar = empleado.numero_cargas * cargaFam.valor;
                        model.monto_familiarvm = empleado.numero_cargas * cargaFam.valor;
                    }
                    else if (haberes.sueldo_base <= 719502)
                    {
                        empleado.asignacion_id = 3;
                        haberes.monto_familiar = empleado.numero_cargas * cargaFam.valor;
                        model.monto_familiarvm = empleado.numero_cargas * cargaFam.valor;
                    }
                    else
                    {
                        empleado.asignacion_id = 4;
                        haberes.monto_familiar = 0;
                        model.monto_familiarvm = 0;
                    }
                    if (empleado.asignacion_id == 1)
                    {

                        haberes.monto_familiar = empleado.numero_cargas * 12364;
                        model.monto_familiarvm = empleado.numero_cargas * 12364;
                    }
                    else if (empleado.asignacion_id == 2)
                    {

                        haberes.monto_familiar = empleado.numero_cargas * 7587;
                        model.monto_familiarvm = empleado.numero_cargas * 7587;
                    }
                    else if (empleado.asignacion_id == 3)
                    {

                        haberes.monto_familiar = empleado.numero_cargas * 2398;
                        model.monto_familiarvm = empleado.numero_cargas * 2398;
                    }
                    else
                    {

                        haberes.monto_familiar = 0;
                        model.monto_familiarvm = 0;
                    }

                    DateTime annos = Convert.ToDateTime(empleado.fecha_contrato);
                    int trabajados = DateTime.Today.AddTicks(-annos.Ticks).Year - 1;

                    if (trabajados == 0) { empleado.antiguedad_id = 10; }
                    else if (trabajados <= 2) { empleado.antiguedad_id = 20; model.bonovm = (beneficio.porcentaje_antiguedad * haberes.sueldo_base) / 100; }
                    else if (trabajados <= 4) { empleado.antiguedad_id = 30; model.bonovm = (beneficio.porcentaje_antiguedad * haberes.sueldo_base) / 100; }
                    else if (trabajados <= 6) { empleado.antiguedad_id = 40; model.bonovm = (beneficio.porcentaje_antiguedad * haberes.sueldo_base) / 100; }
                    else if (trabajados <= 8) { empleado.antiguedad_id = 50; model.bonovm = (beneficio.porcentaje_antiguedad * haberes.sueldo_base) / 100; }
                    else if (trabajados <= 10) { empleado.antiguedad_id = 60; model.bonovm = (beneficio.porcentaje_antiguedad * haberes.sueldo_base) / 100; }
                    else if (trabajados <= 12) { empleado.antiguedad_id = 70; model.bonovm = (beneficio.porcentaje_antiguedad * haberes.sueldo_base) / 100; }
                    else if (trabajados <= 14) { empleado.antiguedad_id = 80; model.bonovm = (beneficio.porcentaje_antiguedad * haberes.sueldo_base) / 100; }
                    else if (trabajados <= 16) { empleado.antiguedad_id = 90; model.bonovm = (beneficio.porcentaje_antiguedad * haberes.sueldo_base) / 100; }
                    else if (trabajados <= 18) { empleado.antiguedad_id = 100; model.bonovm = (beneficio.porcentaje_antiguedad * haberes.sueldo_base) / 100; }
                    else if (trabajados <= 20) { empleado.antiguedad_id = 110; model.bonovm = (beneficio.porcentaje_antiguedad * haberes.sueldo_base) / 100; }
                    else { empleado.antiguedad_id = 110; model.bonovm = (beneficio.porcentaje_antiguedad * haberes.sueldo_base) / 100; }
                    haberes.bono = model.bonovm;

                    if (model.hora_extravm == 0 || model.hora_extravm == null) { haberes.hora_extra = 0; }
                    else
                    {
                        model.calculoHoraExtra = (Convert.ToDouble(model.sueldo_basevm) * 0.0077777) * model.hora_extravm;
                        haberes.hora_extra = model.calculoHoraExtra;
                    }


                    haberes.colacion = model.colacionvm;
                    haberes.movilizacion = model.movilizacionvm;
                    haberes.comision = model.comisionvm;
                    haberes.total_haberes = haberes.sueldo_base + haberes.colacion + haberes.movilizacion + haberes.comision + haberes.hora_extra + haberes.monto_familiar + haberes.bono;

                    //-------------------------------------------//

                    empleado.afp_id = model.AfpId;
                    if (empleado.afp_id == 1) { model.ComisionAFP = 0.1144; }
                    else if (empleado.afp_id == 2) { model.ComisionAFP = 0.1144; }
                    else if (empleado.afp_id == 3) { model.ComisionAFP = 0.1127; }
                    else if (empleado.afp_id == 4) { model.ComisionAFP = 0.1077; }
                    else if (empleado.afp_id == 5) { model.ComisionAFP = 0.1116; }
                    else if (empleado.afp_id == 6) { model.ComisionAFP = 0.1145; }
                    else if (empleado.afp_id == 1002) { model.ComisionAFP = 0; }
                    else { model.ComisionAFP = 0; }
                    descuento.descuento_afp = model.ComisionAFP * Convert.ToDouble(model.sueldo_basevm);
                    //-------------------------------------------//
                    empleado.salud_id = model.SaludId;
                    if (empleado.salud_id == 1) { descuento.descuento_salud= Convert.ToDouble(model.sueldo_basevm)* 0.07; }
                    else if (empleado.salud_id == 2) { descuento.descuento_salud = model.descuento_saludvm; }
                    else if (empleado.salud_id == 1002) { model.ComisionSalud = 0; descuento.descuento_salud = model.ComisionSalud; }
                    
                    if (empleado.desc_id == 10) { descuento.seguro_cesantia = Convert.ToDouble(model.sueldo_basevm) * 0.006; descuento.seguro_vida = 15000;  }
                    else if (empleado.desc_id == 20) { descuento.seguro_cesantia = Convert.ToDouble(model.sueldo_basevm) * 0.006; descuento.seguro_vida = 30000; }
                    else { descuento.seguro_cesantia =0; descuento.seguro_vida = 0; }


                    //-------------------------------------------//






                    db.Entry(descuento).State = System.Data.Entity.EntityState.Modified;
                    db.Entry(haberes).State = System.Data.Entity.EntityState.Modified;
                    db.Entry(empleado).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Perfil", "Empleado", new { rut });
                }
                return RedirectToAction("Index", "Empleado");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}

