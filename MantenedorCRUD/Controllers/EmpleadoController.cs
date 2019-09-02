using MantenedorCRUD.Models;
using MantenedorCRUD.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MantenedorCRUD.Controllers
{
    public class EmpleadoController : Controller
    {
     

        // GET: Empleado
        public ActionResult Index()
        {
            

            List<ListaEmpleadoViewModel> list;
            using (EmpleadosBDEntities db = new EmpleadosBDEntities ())

            {


                list = (from d in db.Empleado
                            select new ListaEmpleadoViewModel
                            {
                                EmpleadoID = d.EmpleadoID,
                                rut = d.rut,
                                amaterno = d.amaterno,
                                apaterno = d.apaterno,
                                direccion = d.direccion,
                                email = d.email,
                                fec_nac = d.fec_nac,
                                foto = d.foto,
                               
                                genero = d.genero,
                                n_profesion = d.n_profesion,
                                pnombre = d.pnombre,
                                annos_xp = d.annos_xp,
                                telefono = d.telefono
                                

            } ).ToList();

                

            }
            return View(list);
        }
        public ActionResult Index2()
        {


            List<ListaEmpleadoViewModel> list;
            using (EmpleadosBDEntities db = new EmpleadosBDEntities())

            {


                list = (from d in db.Empleado
                        select new ListaEmpleadoViewModel
                        {
                            EmpleadoID = d.EmpleadoID,
                            rut = d.rut,
                            amaterno = d.amaterno,
                            apaterno = d.apaterno,
                            direccion = d.direccion,
                            email = d.email,
                            fec_nac = d.fec_nac,
                            foto = d.foto,

                            genero = d.genero,
                            n_profesion = d.n_profesion,
                            pnombre = d.pnombre,
                            annos_xp = d.annos_xp,
                            telefono = d.telefono


                        }).ToList();



            }
            return View(list);
        }
        public ActionResult IndexDark()
        {


            List<ListaEmpleadoViewModel> list;
            using (EmpleadosBDEntities db = new EmpleadosBDEntities())

            {


                list = (from d in db.Empleado
                        select new ListaEmpleadoViewModel
                        {
                            EmpleadoID = d.EmpleadoID,
                            rut = d.rut,
                            amaterno = d.amaterno,
                            apaterno = d.apaterno,
                            direccion = d.direccion,
                            email = d.email,
                            fec_nac = d.fec_nac,
                            foto = d.foto,

                            genero = d.genero,
                            n_profesion = d.n_profesion,
                            pnombre = d.pnombre,
                            annos_xp = d.annos_xp,
                            telefono = d.telefono


                        }).ToList();



            }
            return View(list);
        }


        public ActionResult Informacion()
        {


            List<InformacionEmpleadoViewModel> list;
            using (EmpleadosBDEntities db = new EmpleadosBDEntities())

            {


                list = (from d in db.Parametros_emp
                        select new InformacionEmpleadoViewModel
                        {
                            ParametrosID = d.ParametrosID,
                            EmpleadoID = d.EmpleadoID,
                            valor_hora = d.valor_hora,
                            valor_ex = d.valor_ex,
                            antiguedad = d.antiguedad,
                            isapre = d.isapre,
                            afp = d.afp,
                            cargas_fam = d.cargas_fam,

                            sueldo_bruto = d.sueldo_bruto,
                            sueldo_liquido = d.sueldo_liquido,
                            indemnizacion = d.indemnizacion,
                           


                        }).ToList();



            }
            return View(list);
        }

        public ActionResult RegistrarInformacion()
        {
            return View();

        }

        [HttpPost]
        public ActionResult RegistrarInformacion(InformacionEmpleadoViewModel model)
        {

            try
            {

                if (ModelState.IsValid)
                {
                    using (EmpleadosBDEntities db = new EmpleadosBDEntities())
                    {



                        var oTabla = new Parametros_emp();
                        oTabla.EmpleadoID = model.EmpleadoID;
                        oTabla.ParametrosID = model.ParametrosID;
                        oTabla.afp = model.afp;
                        oTabla.antiguedad = model.antiguedad;
                        oTabla.cargas_fam = model.cargas_fam;
                        oTabla.indemnizacion = model.indemnizacion;
                        oTabla.isapre = model.isapre;
                        oTabla.sueldo_bruto = model.sueldo_bruto;
                        oTabla.sueldo_liquido = model.sueldo_liquido;
                        oTabla.valor_ex = model.valor_ex;
                        oTabla.valor_hora = model.valor_hora;
                       


                        db.Parametros_emp.Add(oTabla);
                        db.SaveChanges();
                    }
                    return Redirect("~/Empleado/Informacion/");
                }

                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public ActionResult Registrar()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Registrar(RegistrarViewModel model)
        {
            
            try
            {
               
                if (ModelState.IsValid)
                {
                    using (EmpleadosBDEntities db = new EmpleadosBDEntities())
                    {

                        

                        var oTabla = new Empleado();
                        oTabla.EmpleadoID = model.EmpleadoID;
                        oTabla.rut = model.rut;
                        oTabla.pnombre = model.pnombre;
                        oTabla.apaterno = model.apaterno;
                        oTabla.amaterno = model.amaterno;
                        oTabla.direccion = model.direccion;
                        oTabla.email = model.email;
                        oTabla.genero = model.genero;
                        oTabla.fec_nac = model.fec_nac;
                        oTabla.annos_xp = model.annos_xp;
                        oTabla.telefono = model.telefono;
                        oTabla.n_profesion = model.n_profesion;
                        oTabla.foto = model.foto;
                       

                        db.Empleado.Add(oTabla);
                        db.SaveChanges();
                    }
                    return Redirect("~/Empleado/");
                }

                return View(model);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            RegistrarViewModel model = new RegistrarViewModel();
            using (EmpleadosBDEntities db = new EmpleadosBDEntities())
            {
                var oTabla = db.Empleado.Find(id);
                model.EmpleadoID = oTabla.EmpleadoID;
                model.rut = oTabla.rut;
                model.pnombre = oTabla.pnombre;
                model.apaterno = oTabla.apaterno;
                model.amaterno = oTabla.amaterno;
                model.direccion = oTabla.direccion;
                model.email = oTabla.email;
                model.genero = oTabla.genero;
                model.fec_nac = oTabla.fec_nac;
                model.annos_xp = oTabla.annos_xp;
                model.telefono = oTabla.telefono;
                model.n_profesion = oTabla.n_profesion;
                model.foto = oTabla.foto;
            }
            return View(model);


        }
        [HttpPost]
        public ActionResult Editar(RegistrarViewModel model)
        {

            try
            {

                if (ModelState.IsValid)
                {
                    using (EmpleadosBDEntities db = new EmpleadosBDEntities())
                    {



                        var oTabla = db.Empleado.Find(model.EmpleadoID);
                        oTabla.EmpleadoID = model.EmpleadoID;
                        oTabla.rut = model.rut;
                        oTabla.pnombre = model.pnombre;
                        oTabla.apaterno = model.apaterno;
                        oTabla.amaterno = model.amaterno;
                        oTabla.direccion = model.direccion;
                        oTabla.email = model.email;
                        oTabla.genero = model.genero;
                        oTabla.fec_nac = model.fec_nac;
                        oTabla.annos_xp = model.annos_xp;
                        oTabla.telefono = model.telefono;
                        oTabla.n_profesion = model.n_profesion;
                        oTabla.foto = model.foto;



                        db.Entry(oTabla).State=System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Empleado/");
                }

                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            RegistrarViewModel model = new RegistrarViewModel();
            using (EmpleadosBDEntities db = new EmpleadosBDEntities())
            {
                var oTabla = db.Empleado.Find(id);
                db.Empleado.Remove(oTabla);
                db.SaveChanges();
            }
            return Redirect("~/Empleado/");


        }
    }




}