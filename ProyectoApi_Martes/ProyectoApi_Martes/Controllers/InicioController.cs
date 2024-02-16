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
        [HttpPost] //debido a que el POST en API es hacer un insert//
        public int RegistrarUsuario(Usuario entidad)
        {
            try
            {
                using (var db = new martes_dbEntities())
                {
                   return db.RegistrarUsuario(entidad.Identificacion, entidad.Contrasenna, entidad.Nombre, entidad.CorreoElectronico);
                }

            }
            catch (Exception ex)
            {
                return -1;
            }
            

        }
    }
}
