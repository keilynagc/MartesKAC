﻿using ProyectoWeb_Martes.Entidades;
using ProyectoWeb_Martes.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace ProyectoWeb_Martes.Controllers
{
    [FiltroSeguridad]
    [FiltroAdmin]
    public class ProductoController : Controller
    {
        ProductoModel modelo = new ProductoModel();

        [HttpGet]
        public ActionResult ConsultaProductos()
        {
            var respuesta = modelo.ConsultarProductos(true);

            if (respuesta.Codigo == 0)
                return View(respuesta.Datos);
            else
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View(new List<Producto>());
            }
        }

        [HttpGet]
        public ActionResult RegistrarProducto()
        {
            CargarViewBagCategorias();
            return View();
        }

        [HttpPost]
        public ActionResult RegistrarProducto(HttpPostedFileBase ImagenProducto, Producto entidad)
        {
            var respuesta = modelo.RegistrarProducto(entidad);

            if (respuesta.Codigo == 0)
            {
                string extension = Path.GetExtension(Path.GetFileName(ImagenProducto.FileName));
                string ruta = AppDomain.CurrentDomain.BaseDirectory + "ImgProductos\\" + respuesta.ConsecutivoGenerado + extension;
                ImagenProducto.SaveAs(ruta);

                entidad.Consecutivo = respuesta.ConsecutivoGenerado;
                entidad.RutaImagen = "/ImgProductos/" + respuesta.ConsecutivoGenerado + extension;
                modelo.ActualizarImagenProducto(entidad);

                return RedirectToAction("ConsultaProductos", "Producto");
            }
            else
            {
                CargarViewBagCategorias();
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
            }
        }

        [HttpGet]
        public ActionResult ActualizarProducto(long id)
        {
            var resp = modelo.ConsultarProducto(id);
            CargarViewBagCategorias();
            ViewBag.urlImagen = resp.Dato.RutaImagen;
            return View(resp.Dato);
        }

        [HttpPost]
        public ActionResult ActualizarProducto(HttpPostedFileBase ImagenProducto, Producto entidad)
        {
            var respuesta = modelo.ActualizarProducto(entidad);

            if (respuesta.Codigo == 0)
            {
                if (ImagenProducto != null)
                {
                    System.IO.File.Delete(AppDomain.CurrentDomain.BaseDirectory + entidad.RutaImagen);

                    string extension = Path.GetExtension(Path.GetFileName(ImagenProducto.FileName));
                    string ruta = AppDomain.CurrentDomain.BaseDirectory + "ImgProductos\\" + entidad.Consecutivo + extension;
                    ImagenProducto.SaveAs(ruta);

                    entidad.RutaImagen = "/ImgProductos/" + entidad.Consecutivo + extension;
                    modelo.ActualizarImagenProducto(entidad);
                }

                return RedirectToAction("ConsultaProductos", "Producto");
            }
            else
            {
                CargarViewBagCategorias();
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
            }
        }

        [HttpGet]
        public ActionResult EliminarProducto(long id)
        {
            var respuesta = modelo.EliminarProducto(id);

            if (respuesta.Codigo == 0)
            {
                return RedirectToAction("ConsultaProductos", "Producto");
            }
            else
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
            }
        }

        private void CargarViewBagCategorias()
        {
            var respuesta = modelo.ConsultarTiposCategoria();
            var tiposCategoria = new List<SelectListItem>();

            tiposCategoria.Add(new SelectListItem { Text = "Seleccione una categoría", Value = "" });
            foreach (var item in respuesta.Datos)
                tiposCategoria.Add(new SelectListItem { Text = item.NombreCategoria, Value = item.IdCategoria.ToString() });

            ViewBag.TiposCategoria = tiposCategoria;
        }

    }
}