using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAPP_GESTIONEMPLEADOS.Models.ViewModels
{
    public class DescuentoViewModel
    {
        public int id { get; set; }
        public int rut_empleado { get; set; }
        public Nullable<double> descuento_afp { get; set; }
        public Nullable<double> seguro_vida { get; set; }
        public Nullable<double> descuento_salud { get; set; }
        public Nullable<double> seguro_cesantia { get; set; }
        public Nullable<double> total_descuentos { get; set; }
    }
}