using AppLocationVehicleASP.Bases;
using AppLocationVehicleASP.Models;
using AppLocationVehicleASP.Models.Forms;
using AppLocationVehicleASP.Services;
using AppLocationVehicleASP.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AppLocationVehicleASP.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IService<Reservation, ReservationForm> _service;
        private readonly ISecurity _userService;
        public ReservationController(IService<Reservation, ReservationForm> s, ISecurity userService)
        {
            _service = s;
            _userService = userService;
        }

        // GET: ReservationController
        public IActionResult ReservationByUser(string token)
        {
            User user = HttpContext.Session.Get<User>("user");
            if (user is null) return View("NotConnected");
            //using (HttpClient client = new HttpClient())
            //{
            //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            //    HttpResponseMessage rep = client.GetAsync("http://localhost:15148/api/reservation/user/id").Result;
            //    if (rep.IsSuccessStatusCode)
            //    {
            //        string json = rep.Content.ReadAsStringAsync().Result;
            //        return (ActionResult)JsonConvert.DeserializeObject<IEnumerable<Reservation>>(json);
            //    }
            //    //return null;
            //}
            return View("Index",((ReservationService)_service).GetAllById(user.Id));
            
        }

        // GET: ReservationController/Details/5
        public ActionResult Details(int id)
        {
            Reservation reservation = _service.GetById(HttpContext.Session.Get<int>("UserId"));

            return View(reservation);
        }

        // GET: ReservationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReservationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReservationForm form)
        {
            //Correct ?
            //Si oui
            //if (ModelState.IsValid)
            //{
            //    form.UserId = HttpContext.Session.Get<int>("UserId");
            //    _deckService.Insert(form);
            //    TempData["success"] = "Insertion effectuée";
            //    return RedirectToAction("Index");
            //}
            //else
            //{
            //    return View(form);
            //}
            //////////////////////////////////////////
            if (ModelState.IsValid)
            {
                //Service
                //_requester.Post<ReservationForm>(form, "Reservation", SessionUtils.ConnectedUser.Token);

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

            //Si un utilisateur est connecté, il peut reserver un vehicule. Pour cela il faut :

            // - Enregistrer une agence => car l'on veut savoir à quelle agence on loue le vehicule
            //   et les infos liées à cette agence
            //foreach (var item in collection)
            //{
            //    foreach (var item in collection)
            //    {
            //        //Details Category
            //        //Details Disponibilities
            //        //Details Vehicle
            //        //Details State
            //    }

            //}
            // - Enregistrer une categorie => car l'utilisateur reserve une catégorie de véhicule
            // - Enregisrter une disponibilité => car l'on veut savoir les disponibilités des véhicule en
            //   fonctions des dates (depart et retour) des véhicules
            // - Enregistrer un vehicule => car l'on veut savoir le model(y compris la marque) du véhicule
            //   et aussi si le véhicule appartient à quelle agence
            // - Enregistrer un état => lorsque l'on reserve un véhicule, son état doit
            //   changer(de "en agence" à "en location")

            //Une fois que la reservation est effectuée, un contrat est établit(seulement si le client a
            //"tout payé") => ensuite une facture est générée par la suite
        }

        // GET: ReservationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReservationController/Edit/5
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

        // GET: ReservationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReservationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete([FromRoute]int id, IFormCollection collection)
        {
            if (_service.Delete(id))
            {
                TempData["success"] = "Suppression OK";
            }
            else
            {
                TempData["error"] = "Erreur de suppression";
            }
            return RedirectToAction("Index");
        }
    }
}
