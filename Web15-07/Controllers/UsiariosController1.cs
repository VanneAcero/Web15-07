using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web15_07.Controllers
{
    public class UsiariosController1 : Controller
    {
        // GET: UsiariosController1
        public ActionResult Index()
        {
            return View();
        }

        // GET: UsiariosController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsiariosController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsiariosController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsiariosController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsiariosController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsiariosController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsiariosController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
