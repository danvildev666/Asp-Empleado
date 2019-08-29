using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MantenedorCRUD.Models.ViewModels
{
    public class RegistrarViewModel
    {
        [Required]
        [Display(Name = "ID:")]
        public int EmpleadoID { get; set; }

        [Required]
        [StringLength(12)]
        [Display(Name = "Rut:")]
        public string rut { get; set; }

        [Required]
        [StringLength(25)]
        [Display(Name = "Nombre:")]
        public string pnombre { get; set; }
        [Required]
        [StringLength(25)]
        [Display(Name = "Apellido Paterno:")]
        public string apaterno { get; set; }
        [Required]
        [StringLength(25)]
        [Display(Name = "Apellido Materno:")]
        public string amaterno { get; set; }
        [Required]
        [Display(Name = "Años de experiencia:")]
        public int annos_xp { get; set; }
        [Required]
        [StringLength(25)]
        [Display(Name = "Genero:")]
        public string genero { get; set; }
        [Required] 
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Nacimiento:")]
        public DateTime fec_nac { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email:")]
        public string email { get; set; }
        [Required]
        [StringLength(12)]
        [Display(Name = "Teléfono:")]
        public string telefono { get; set; }
        [Required]
        [StringLength(30)]
        [Display(Name = "Dirección:")]
        public string direccion { get; set; }
        [Required]
        [StringLength(25)]
        [Display(Name = "Nombre Profesión:")]
        public string n_profesion { get; set; }
       
        [Display(Name = "Foto:")]
        public byte[] foto { get; set; }
    }
}