using AppLocationVehicleASP.Models;
using AppLocationVehicleASP.Models.Forms;
using AppLocationVehicleASP.Tools;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppLocationVehicleASP.Controllers
{
    public class AgencyController : Controller
    {
        // Ceci correspond à mon service => mon Requester
        private readonly ISecurity _requester;

        public AgencyController(ISecurity requester)
        {
            _requester = requester;
        }


        // GET: Agency
        public IActionResult Index()
        {
            return View(_requester.Get<IEnumerable<Agency>>("Agency"));
        }

        // GET: Agency/Details/5
        public ActionResult Details(int id)
        {
            return View(_requester.Get<Agency>("Agency/" + id));
        }

        // Affichage du formulaire
        // GET: Agency/Create
        public IActionResult Create()
        {
            return View();
        }

        // Traitement du formulaire
        // POST: Agency/Create
        [HttpPost]
        public IActionResult Create(AgencyForm form)
        {
            //Correct ?
            //Si oui
            if (ModelState.IsValid)
            {
                //Service
                _requester.Post(form, "Agency");

                //On affiche une notification
                TempData["success"] = "Insertion OK";

                //En suite, on fait une redirection
                return RedirectToAction(nameof(Index));
            }
            else
            {
                //Si non
                //Réafficher la vue avec le form et les erreurs
                return View(form);
            }
        }

        // GET: Agency/Update/5
        public ActionResult Update(int id)
        {
            return View(_requester.Get<AgencyForm>("Agency/" + id));
        }

        // POST: Agency/Update/5
        //Traitement de la modification avec un [HttpPost]
        [HttpPost]
        public IActionResult Update(int id, AgencyForm form)
        {
            if (ModelState.IsValid)
            {
                _requester.Update(form, "Agency/"+id);
                TempData["success"] = "Modification OK";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(form);
            }
        }

        // GET: Agency/Delete/5
        public IActionResult Delete([FromRoute] int id)
        {
            _requester.Delete(id, "Agency/");
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete, ActionName("Delete")]//Eviter ActionName pour la maintenabilité
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id, Agency agency)
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
