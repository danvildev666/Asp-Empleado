using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MantenedorCRUD.Models.ViewModels
{
    public class ListaEmpleadoViewModel
    {

        public int EmpleadoID { get; set; }
        public string rut { get; set; }
        public string pnombre { get; set; }
        public string apaterno { get; set; }
        public string amaterno { get; set; }
        public int annos_xp { get; set; }
        public string genero { get; set; }

        public DateTime fec_nac { get; set; }

       

        public string email { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public string n_profesion { get; set; }
        public byte[] foto { get; set; }

        
        

    }
}