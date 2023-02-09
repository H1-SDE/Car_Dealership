using car_dealership.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using dal;
using System.Data;
using System.Text.Json;
using System.Collections.Generic;

namespace car_dealership.Controllers
{
    public class EmplysController : Controller
    {
        // GET: Emplys
        public ActionResult Index()
        {
            Conductos conductos = new Conductos();
            string getEmplyJson = conductos.GetEmply();
            List<EmplyModel> list = JsonSerializer.Deserialize<List<EmplyModel>>(getEmplyJson)!;
            return View(list);
        }


        // GET: Emplys/Details/5
        public ActionResult Details(int id)
        {
            Conductos conductos = new Conductos();
            EmplyModel emplyModel = new EmplyModel();
            string getEmplyByIdJson = conductos.GetEmply(id);
            List<EmplyModel> list = JsonSerializer.Deserialize<List<EmplyModel>>(getEmplyByIdJson);
            foreach (var item in list)
            {
                emplyModel.EmplyID = item.EmplyID;
                emplyModel.Initial = item.Initial;
                emplyModel.FirstName = item.FirstName;
                emplyModel.LastName = item.LastName;
                emplyModel.Type = item.Type;


            }
            return View(emplyModel);
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
            Conductos conductos = new Conductos();
            EmplyModel emplyModel = new EmplyModel();
            string getEmplyByIdJson = conductos.GetEmply(id);
            List<EmplyModel> list = JsonSerializer.Deserialize<List<EmplyModel>>(getEmplyByIdJson);
            foreach (var item in list)
            {
                emplyModel.EmplyID = item.EmplyID;
                emplyModel.Initial = item.Initial;
                emplyModel.FirstName = item.FirstName;
                emplyModel.LastName = item.LastName;
                emplyModel.Type = item.Type;


            }
            return View(emplyModel);
        }

        // POST: Emplys/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Conductos conductos = new Conductos();
                conductos.DeleteEmply(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
