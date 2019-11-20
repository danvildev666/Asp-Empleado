using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAPP_GESTIONEMPLEADOS.Models;
using MVCAPP_GESTIONEMPLEADOS.Models.ViewModels;

namespace MVCAPP_GESTIONEMPLEADOS.Programacion
{
    public class AutoCompletar
    {
        [HttpPost]
        public void IA(PerfilViewModel model, int rut)
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
            //-------------------------------------------//

            var Haberes = new Haberes();
            var Descuento = new Descuento();
            var empleadoG = db.Empleado.Find(rut);
            //-------------------------------------------//
            model.SaludId = 1002;
            model.AntiguedadId = 10;
            model.AsignacionId = 5;
            model.AfpId = 1002;
            model.DescuentoId = 30;
            //-------------------------------------------//

            if (HaberesQ == null || DescuentoQ == null)
            {
                Haberes.rut_empleado = rut;
                Descuento.rut_empleado = rut;

                Haberes.hora_extra = 0;
                Haberes.monto_familiar = 0;
                Haberes.sueldo_base = 0;
                Haberes.total_haberes = 0;
                Haberes.colacion = 0;
                Haberes.comision = 0;
                Haberes.movilizacion = 0;
                Haberes.bono = 0;
                Descuento.descuento_afp = 0;
                Descuento.descuento_salud = 0;
                Descuento.seguro_cesantia = 0;
                Descuento.seguro_vida = 0;
                Descuento.total_descuentos = 0;
                            
                db.Haberes.Add(Haberes);
                db.Descuento.Add(Descuento);
                db.SaveChanges();
            }
          /*  else if (empleadoG.salud_id == null || empleadoG.desc_id == null || empleadoG.afp_id == null || empleadoG.asignacion_id == null || empleadoG.antiguedad_id == null)
            {

                empleadoG.salud_id = model.SaludId;
                empleadoG.antiguedad_id = model.AntiguedadId;
                empleadoG.asignacion_id = model.AsignacionId;
                empleadoG.afp_id = model.AfpId;
                empleadoG.desc_id = model.DescuentoId;
                //-------------------------------------------//
                db.Entry(empleadoG).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                //-------------------------------------------//
            }
            */
        }
    }
}