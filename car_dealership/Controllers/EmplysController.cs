﻿using car_dealership.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using dal;
using System.Data;

namespace car_dealership.Controllers
{
    public class EmplysController : Controller
    {
        // GET: Emplys
        public ActionResult Index()
        {
            Conductos conductos = new Conductos();
            conductos.GetEmply();
            //foreach(var item in conductos.GetEmply())
            //{
            //    return View(item);
            //}
            return View();
        }

        public ActionResult Index2(EmplyModel emply)
        {
            Conductos conductos = new Conductos();
            foreach(var item in conductos.GetEmply())
            {
                emply.FirstName += item;
                emply.LastName += item;
                emply.Type += item;

            }
            return View(emply);
        }

        // GET: Emplys/Details
        public ActionResult Details()
        {

            Conductos conductos = new Conductos();
            conductos.GetEmply();
            return View();
        }

        // GET: Emplys/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Emplys/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Emplys/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmplyModel emply)
        {
            try
            {
                Conductos conductos = new Conductos();
                conductos.AddEmply(emply.FirstName!, emply.LastName!, emply.Type!);
                ViewData["Message"] = " BALALAALA";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Emplys/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Emplys/Edit/5
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

        // GET: Emplys/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Emplys/Delete/5
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