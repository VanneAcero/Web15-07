﻿using EjercicioCrud20_07.Data;
using EjercicioCrud20_07.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EjercicioCrud20_07.Controllers
{
    [Authorize]
    public class PersonasController : Controller
    {
                    
        private readonly ApplicationDbContext _applicationDbContext;
        public PersonasController (ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [Authorize (Roles ="Generador,Cliente")] 
        public IActionResult Index()
        {
            List<Persona> personas = new List<Persona>();
            try
            {
                personas = _applicationDbContext.Persona.ToList();
            }
            catch (Exception ex)
            {

            }
                 
               //personas= _applicationDbContext.Persona.ToList();
            
                return View(personas);
            

        }
        [Authorize(Roles = "Generador, Cliente")]
        public IActionResult Details(int Codigo)
        {

            if (Codigo == 0)
                return RedirectToAction("Index");
            Persona persona = _applicationDbContext.Persona.Where(v => v.Codigo == Codigo).FirstOrDefault();
            if (persona == null)
                return RedirectToAction("Index");
            return View(persona);
        }
        [Authorize(Roles = "Generador")]
        public IActionResult Create()
        {
            
            return View();
        }
        [Authorize(Roles = "Generador")]
        [HttpPost]
        public IActionResult Create(Persona persona)
        {
            try
            {
                persona.Estado = 1;
                _applicationDbContext.Add(persona);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception)
            {
                return View(persona);
            }
            
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Generador")]
        public IActionResult Edit(int id)
        {
            if (id == 0)
            
                return RedirectToAction("Index");
            

            Persona persona = _applicationDbContext.Persona.Where(v => v.Codigo == id).FirstOrDefault();
            if (persona == null)
                return RedirectToAction("Index");
            return View(persona);
        }
        [Authorize(Roles = "Generador")]
        [HttpPost]
        public IActionResult Edit (int id,Persona persona)
        {
            if (id != persona.Codigo)
                return RedirectToAction("Index");
            try
            {
                persona.Estado = 1;
                _applicationDbContext.Update(persona);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception)
            {
                return View(persona);
            }

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Generador")]
        public IActionResult Desactivar (int id)
        {
            if (id == 0)

                return RedirectToAction("Index");


            Persona persona = _applicationDbContext.Persona.Where(v => v.Codigo == id).FirstOrDefault();
            try
            {
                persona.Estado = 0;
                _applicationDbContext.Update(persona);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }
        [Authorize(Roles = "Generador")]
        public IActionResult Activar(int id)
        {
            if (id == 0)

                return RedirectToAction("Index");


            Persona persona = _applicationDbContext.Persona.Where(v => v.Codigo == id).FirstOrDefault();
            try
            {
                persona.Estado = 1;
                _applicationDbContext.Update(persona);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }
    }
}
