using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lembrete.Presentation.Controllers
{
    public class LembreteController : Controller
    {
        // GET: Lembrete
        public ActionResult Index()
        {
            return View();
        }

        // GET: Lembrete/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Lembrete/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lembrete/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Lembrete/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Lembrete/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Lembrete/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Lembrete/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}