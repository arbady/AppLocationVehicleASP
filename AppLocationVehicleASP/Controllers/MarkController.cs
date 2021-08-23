using AppLocationVehicleASP.Models;
using AppLocationVehicleASP.Models.Forms;
using AppLocationVehicleASP.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppLocationVehicleASP.Controllers
{
    public class MarkController : Controller
    {
        private readonly ApiRequester _requester;

        public MarkController()
        {
            _requester = new ApiRequester("http://localhost:15148/api/");
        }

        // GET: MarkController
        public ActionResult Index()
        {
            return View(_requester.Get<IEnumerable<Mark>>("Mark"));
        }

        // GET: MarkController/Details/5
        public ActionResult Details(int id)
        {
            return View(_requester.Get<Agency>("Mark/" + id));
        }

        // Affichage du formulaire
        // GET: Mark/Create
        public IActionResult Create()
        {
            return View();
        }

        // Traitement du formulaire
        // POST: Mark/Create
        [HttpPost]
        public IActionResult Create(MarkForm form)
        {
            //Correct ?
            //Si oui
            if (ModelState.IsValid)
            {
                //Service
                _requester.Post<MarkForm>(form, "Mark");

                //On affiche une notification
                TempData["success"] = "Insertion OK";

                //En suite, on fait une redirection
                return RedirectToAction("Index");
            }
            else
            {
                //Si non
                //Réafficher la vue avec le form et les erreurs
                return View(form);
            }
        }

        // GET: MarkController/Edit/5
        public ActionResult Update(int id)
        {
            return View(_requester.Get<MarkForm>("Mark/" + id));
        }

        // POST: Mark/Update/5
        //Traitement de la modification avec un [HttpPost]
        [HttpPost]
        public IActionResult Update(int id, MarkForm form)
        {
            if (ModelState.IsValid)
            {
                _requester.Update<MarkForm>(form, "Mark" + id);
                TempData["success"] = "Modification OK";
                return RedirectToAction("Index");
            }
            else
            {
                return View(form);
            }
        }

        // GET: Mark/Delete/5
        public IActionResult Delete([FromRoute] int id)
        {
            _requester.Delete(id, "Mark/");
            return RedirectToAction("Index");
        }

        // POST: MarkController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, MarkForm form)
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
