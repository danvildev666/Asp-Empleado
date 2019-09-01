using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MantenedorCRUD.Models.ViewModels
{
    public class InformacionEmpleadoViewModel
    {
        public int ParametrosID { get; set; }
        public int EmpleadoID { get; set; }
        public double valor_hora { get; set; }
        public double valor_ex { get; set; }
        public int antiguedad { get; set; }
        public double isapre { get; set; }
        public double afp { get; set; }
        public int cargas_fam { get; set; }
        public double sueldo_bruto { get; set; }
        public double sueldo_liquido { get; set; }
        public double indemnizacion { get; set; }

    }
}