using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAPP_GESTIONEMPLEADOS.Models.ViewModels
{
    public class OtrosDescuentosViewModel
    {

        public int id { get; set; }
        public Nullable<double> seguro_vida { get; set; }
        public Nullable<double> seguro_cesantia { get; set; }

    }
}