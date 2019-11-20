using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAPP_GESTIONEMPLEADOS.Models;
using MVCAPP_GESTIONEMPLEADOS.Models.ViewModels;


namespace MVCAPP_GESTIONEMPLEADOS.Programacion
{
    public class Calculos
    {
        [HttpPost]
        public void CalculoHaberes(PerfilViewModel model, int rut)
        {
            GestionEmpleadosDBEntities db = new GestionEmpleadosDBEntities();
            var Empleado = (from d in db.Empleado  where d.rut == rut select d).FirstOrDefault();

            var haberes = (from hab in db.Haberes
                           join emp in db.Empleado on hab.rut_empleado equals emp.rut
                           where emp.rut == rut
                           select hab).FirstOrDefault();

            var cargaFam = (from d in db.Empleado
                            join c in db.Asignacion_familiar on d.asignacion_id equals c.Id
                            where d.rut == rut
                            select c).FirstOrDefault();




            Empleado.sueldo_base = Convert.ToDouble(model.sueldo_basevm);

           
            db.Entry(haberes).State = System.Data.Entity.EntityState.Modified;
            db.Entry(Empleado).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();



        }
    }

}