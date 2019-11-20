using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAPP_GESTIONEMPLEADOS.Models.ViewModels
{
    public class BeneficioAntiguedadViewModel
    {
        public int Id { get; set; }
        public Nullable<int> Annos_Antiguedad { get; set; }
        public Nullable<double> porcentaje_antiguedad { get; set; }
    }
}