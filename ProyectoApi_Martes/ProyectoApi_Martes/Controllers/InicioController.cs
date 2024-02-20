using ProyectoApi_Martes.Entidades;
using ProyectoApi_Martes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProyectoApi_Martes.Controllers
{
   
    public class InicioController : ApiController
    {
        [Route("Inicio/RegistrarUsuario")]
        [HttpPost]  //debido a que el POST en API es hacer un insert//
        public Confirmacion RegistrarUsuario(Usuario entidad)
        {
            Confirmacion respuesta = new Confirmacion();

            try
            {
                using (var db = new martes_dbEntities())
                {
                   var resp = db.RegistrarUsuario(entidad.Identificacion, entidad.Contrasenna, entidad.Nombre, entidad.CorreoElectronico);

                    if (resp > 0) //afectó a más de 1 línea, quiere decir se realizó el registro enviado//
                    {
                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "Su información ya se encuentra registrada";

                    }
                }
            }
            catch (Exception)
            {
                respuesta.Codigo = -1;
                respuesta.Detalle = "Su información no se pudo registrar"; // no es buena practica mostrarle el error al usuario, mejor se guarda en un registro en la BD//
            }
            return respuesta;
        }

        [Route("Inicio/IniciarSesionUsuario")]
        [HttpPost] //LO HACEMOS POST PARA CUIDAR QUE LOS DATOS NO VIAJEN POR LA URL//
        public ConfirmacionUsuario IniciarSesionUsuario(Usuario entidad)
        {
            var respuesta = new ConfirmacionUsuario();

            try
            {
                using (var db = new martes_dbEntities())
                {
                    var datos = db.IniciarSesionUsuario(entidad.Identificacion, entidad.Contrasenna).FirstOrDefault();
                    if (datos != null)
                    {
                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;
                        respuesta.Dato = datos; //Dato porque es solo 1 una persona//
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "No se pudo validar su información de ingreso";
                    }
                }
            }
            catch (Exception)
            {
                respuesta.Codigo = -1;
                respuesta.Detalle = "Se presentó un error en el sistema";
            }
            return respuesta;
        }

    
    }
}
