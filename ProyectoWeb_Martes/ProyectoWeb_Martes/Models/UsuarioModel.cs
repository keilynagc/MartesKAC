using ProyectoWeb_Martes.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
//Conectando el API a la BD//
namespace ProyectoWeb_Martes.Models
{

    public class UsuarioModel
    {
        public string url = "https://localhost:44328/";

        public int RegistrarUsuario(Usuario entidad)
        {
            using (var client = new HttpClient())
            {
                //Capturamos la respuesta POST//
                url += "Inicio/RegistrarUsuario";
                JsonContent jsonEntidad = JsonContent.Create(entidad);
                var respuesta = client.PostAsync(url, jsonEntidad).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<int>().Result;
                return 0;
                

            }

        }

        public List<Usuario> IniciarSesionUsuario(Usuario entidad)
        {
            using (var client = new HttpClient())
            {
                //Capturamos la respuesta POST//
                url += "Inicio/IniciarSesionUsuario";
                JsonContent jsonEntidad = JsonContent.Create(entidad);
                var respuesta = client.PostAsync(url, jsonEntidad).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<List<Usuario>>().Result;

                return null;


            }

        }


    }
}