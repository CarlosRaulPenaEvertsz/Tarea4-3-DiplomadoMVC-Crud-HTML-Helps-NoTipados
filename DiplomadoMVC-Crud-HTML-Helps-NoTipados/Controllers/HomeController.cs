﻿using DiplomadoMVC_Crud_HTML_Helps_NoTipados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiplomadoMVC_Crud_HTML_Helps_NoTipados.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection coleccion)
        { 
            if (coleccion["Codigo"].ToString()=="") // Para evitar error del programa
                coleccion["Codigo"] = "0";
            MantenimientoProductos mp = new MantenimientoProductos();
            Productos prod = mp.Recuperar(int.Parse(coleccion["Codigo"].ToString()));
            if (prod != null)
                return View("ModificacionProducto", prod);
            else
                return View("ProductoNoExistente");
        }

        [HttpPost]
        public ActionResult ModificacionProducto(FormCollection coleccion)
        {
            MantenimientoProductos mp = new MantenimientoProductos();
            Productos prod = new Productos
            {
                Codigo = int.Parse(coleccion["Codigo"].ToString()),
                Descripcion = coleccion["Descripcion"].ToString(),
                Precio = float.Parse(coleccion["Precio"].ToString())
            };
            mp.Modificar(prod);
            return RedirectToAction("Index");

        }

        public ActionResult Grabar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Grabar(FormCollection coleccion)
        {
            MantenimientoProductos mp = new MantenimientoProductos();
            Productos prod = new Productos
            {
                Descripcion = coleccion["Descripcion"],
                Precio = float.Parse(coleccion["Precio"].ToString())
            };
            mp.Agregar(prod);
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}