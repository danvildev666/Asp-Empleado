using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAPP_GESTIONEMPLEADOS.Models.ViewModels
{
    public class AfpViewModel
    {
       
        public int Id { get; set; }
        public string nombre { get; set; }
        public Nullable<double> comision { get; set; }
    }
}