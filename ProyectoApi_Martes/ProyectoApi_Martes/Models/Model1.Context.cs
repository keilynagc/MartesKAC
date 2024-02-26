﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoApi_Martes.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class martes_dbEntities : DbContext
    {
        public martes_dbEntities()
            : base("name=martes_dbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual ObjectResult<ConsultarProductos_Result> ConsultarProductos(Nullable<bool> mostrarTodos)
        {
            var mostrarTodosParameter = mostrarTodos.HasValue ?
                new ObjectParameter("MostrarTodos", mostrarTodos) :
                new ObjectParameter("MostrarTodos", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ConsultarProductos_Result>("ConsultarProductos", mostrarTodosParameter);
        }
    
        public virtual ObjectResult<IniciarSesionUsuario_Result> IniciarSesionUsuario(string identificacion, string contrasenna)
        {
            var identificacionParameter = identificacion != null ?
                new ObjectParameter("Identificacion", identificacion) :
                new ObjectParameter("Identificacion", typeof(string));
    
            var contrasennaParameter = contrasenna != null ?
                new ObjectParameter("Contrasenna", contrasenna) :
                new ObjectParameter("Contrasenna", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<IniciarSesionUsuario_Result>("IniciarSesionUsuario", identificacionParameter, contrasennaParameter);
        }
    
        public virtual ObjectResult<RecuperarAccesoUsuario_Result> RecuperarAccesoUsuario(string identificacion, string correoElectronico)
        {
            var identificacionParameter = identificacion != null ?
                new ObjectParameter("Identificacion", identificacion) :
                new ObjectParameter("Identificacion", typeof(string));
    
            var correoElectronicoParameter = correoElectronico != null ?
                new ObjectParameter("CorreoElectronico", correoElectronico) :
                new ObjectParameter("CorreoElectronico", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<RecuperarAccesoUsuario_Result>("RecuperarAccesoUsuario", identificacionParameter, correoElectronicoParameter);
        }
    
        public virtual int RegistrarUsuario(string identificacion, string contrasenna, string nombre, string correoElectronico)
        {
            var identificacionParameter = identificacion != null ?
                new ObjectParameter("Identificacion", identificacion) :
                new ObjectParameter("Identificacion", typeof(string));
    
            var contrasennaParameter = contrasenna != null ?
                new ObjectParameter("Contrasenna", contrasenna) :
                new ObjectParameter("Contrasenna", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var correoElectronicoParameter = correoElectronico != null ?
                new ObjectParameter("CorreoElectronico", correoElectronico) :
                new ObjectParameter("CorreoElectronico", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("RegistrarUsuario", identificacionParameter, contrasennaParameter, nombreParameter, correoElectronicoParameter);
        }
    }
}
