using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAPP_GESTIONEMPLEADOS.Models.ViewModels
{
    public class HaberesViewModel
    {
        public int id { get; set; }
        public int rut_empleado { get; set; }
        public Nullable<double> hora_extra { get; set; }
        public Nullable<double> comision { get; set; }
        public Nullable<double> bono { get; set; }
        public Nullable<double> colacion { get; set; }
        public Nullable<double> movilizacion { get; set; }
        public Nullable<double> sueldo_base { get; set; }
        public Nullable<double> monto_familiar { get; set; }
        public Nullable<double> total_haberes { get; set; }
    }
}