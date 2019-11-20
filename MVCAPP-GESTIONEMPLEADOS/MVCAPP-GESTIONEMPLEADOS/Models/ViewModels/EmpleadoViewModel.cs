using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCAPP_GESTIONEMPLEADOS.Models.ViewModels
{
    public class EmpleadoViewModel
    {
        
        public List<Afp> AfpLista { get; set; }
        public List<Salud> PrevisionLista { get; set; }
        public List<Otros_Descuentos> OtrosDescuentosLista { get; set; }
        public int IdEmpleado { get; set; }
        [Required]
        public int rut { get; set; }
        [Required]
        public string dv { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public string apaterno { get; set; }
        [Required]
        public string amaterno { get; set; }
        public Nullable<int> annos_experiencia { get; set; }
        [Required]
        public string genero { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> fecha_nacimiento { get; set; }
        [EmailAddress]
        public string email { get; set; }
        [Required]
        public Nullable<int> telefono { get; set; }
        [Required]
        public string direccion { get; set; }
        [Required]
        public string nombre_profesion { get; set; }

        public Nullable<int> numero_cargas { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> fecha_contrato { get; set; }
        public Nullable<int> salud_id { get; set; }
        public Nullable<int> afp_id { get; set; }
        public Nullable<int> desc_id { get; set; }
        public Nullable<int> asignacion_id { get; set; }
        public Nullable<int> antiguedad_id { get; set; }
        public Nullable<double> sueldo_base { get; set; }
        public Nullable<double> sueldo_liquido { get; set; }
    }
}