using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAPP_GESTIONEMPLEADOS.Models;

namespace MVCAPP_GESTIONEMPLEADOS.Models.ViewModels
{
    public class PerfilViewModel
    {
        //-----------------------------------//
        public Empleado empleado { get; set; }
        public Afp afp { get; set; }
        public Asignacion_familiar asignacion_familiar { get; set; }
        public Beneficio_Antiguedad beneficio_antiguedad { get; set; }
        public Descuento descuento { get; set; }
        public Otros_Descuentos otros_descuentos { get; set; }
        public Haberes haberes { get; set; }
        public Salud salud { get; set; }
        //-----------------------------------//
        [NotMapped]
        public List<Afp> AfpLista { get; set; }
        public List<Salud> PrevisionLista { get; set; }

        //-----------------------------------//
        public int Rut { get; set; }
        public string NombreAfp { get; set; }
        public Nullable<double> ComisionAFP { get; set; }
        public Nullable<double> ComisionSalud{ get; set; }
        public string sueldo_basevm { get; set; }
        public Nullable<int> AfpId { get; set; }
        public Nullable<int> SaludId { get; set; }
        public Nullable<int> DescuentoId { get; set; }
        public Nullable<int> AsignacionId { get; set; }
        public Nullable<int> AntiguedadId { get; set; }
        //-----------------------------------//
        public Nullable<double> hora_extravm { get; set; }
        public Nullable<double> comisionvm { get; set; }
        public Nullable<double> bonovm { get; set; }
        public Nullable<double> colacionvm { get; set; }
        public Nullable<double> movilizacionvm { get; set; }
        //-----------------------------------//
        public Nullable<double> monto_familiarvm { get; set; }
        public Nullable<double> total_haberesvm { get; set; }
        public Nullable<double> descuento_afpvm { get; set; }
        public Nullable<double> descuento_cesantiavm { get; set; }
        public Nullable<double> descuento_segurovidavm { get; set; }
        public Nullable<double> descuento_saludvm { get; set; }
        public Nullable<double> total_descuentosvm { get; set; }
        public Nullable<double> seguro_vidavm { get; set; }
        public Nullable<double> seguro_cesantiavm { get; set; }
        public Nullable<double> sueldo_liquidovm { get; set; }
        public Nullable<double> calculoHoraExtra { get; set; }
        public string TieneCargavm { get; set; }
        public string tiposaludvm { get; set; }


       

    }
    }

