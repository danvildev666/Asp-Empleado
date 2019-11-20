using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAPP_GESTIONEMPLEADOS.Models.ViewModels
{
    public class SaludViewModel
    {
        public int Id { get; set; }
        public string tipo_salud { get; set; }
        public Nullable<double> descuento_salud { get; set; }
    }
}