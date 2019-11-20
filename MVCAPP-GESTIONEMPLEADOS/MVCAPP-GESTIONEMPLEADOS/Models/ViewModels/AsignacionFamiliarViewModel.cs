using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAPP_GESTIONEMPLEADOS.Models.ViewModels
{
    public class AsignacionFamiliarViewModel
    {
        public int Id { get; set; }
        public Nullable<double> valor { get; set; }
        public string tramo { get; set; }

    }
}