using AppLocationVehicleASP.Bases;
using AppLocationVehicleASP.Models;
using AppLocationVehicleASP.Models.Forms;
using AppLocationVehicleASP.Services;
using AppLocationVehicleASP.Services.Base;
using AppLocationVehicleASP.Tools;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppLocationVehicleASP.Controllers
{
    //[Authorize]
    public class SecurityController : Controller
    {
        private readonly ISecurity _service;
        private readonly IServiceUser<User, UserForm> _uservice;

        public SecurityController(ISecurity s, IServiceUser<User, UserForm> us)
        {
            _service = s;
            _uservice = us;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LogOut()
        {
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login() { return View(); }

        [HttpPost]
        public IActionResult Login(LoginForm form)
        {
            if (ModelState.IsValid)
            {

                User user = _service.Post<LoginForm, User>(form, "Security/Login");
                if (user is null) return BadRequest();
                int userId = user.Id;

                //if (userId != 0)
                //{
                //    SessionUtils.ConnectedUser = user;
                //    SessionUtils.IsLogged = true;
                //    HttpContext.Session.Set("user", user);
                //    //return RedirectToAction(nameof(Index), "Home", new { id = SessionUtils.ConnectedUser.Id });
                //    return RedirectToAction("Index", "Home");
                //}
                
                //int userId = (_uservice as UserService).Login(form.Email, form.Password);

                if (userId != 0)
                {
                    SessionUtils.ConnectedUser = user;
                    HttpContext.Session.Set<bool>("IsLogged", true);
                    TempData["isLogged"] = HttpContext.Session.Get<bool>("IsLogged");
                    HttpContext.Session.Set<User>("user", user);

                    return RedirectToAction("Index", "Home", new { id = HttpContext.Session.Get<User>("user") });
                }
                else
                {
                    TempData["error"] = "Identifiant ou mot de passe invalide";
                    return View(form);
                }
            }
            else
            {
                TempData["error"] = "formulaire invalide";
                return View(form);
            }
        }

        public IActionResult Register() { return View(); }
        public IActionResult Register(UserForm form)
        {
            if (ModelState.IsValid)
            {
                _service.Post<UserForm>(form, "Register");
                HttpContext.Session.Set<int>("UserId", form.Id);
                TempData["succes"] = "Insertion effectuée";
                HttpContext.Session.Set<bool>("IsLogged", true);

                return RedirectToAction(nameof(Index), "Home", new
                {
                    id = HttpContext.Session.Get<int>("UserId")
                });
            }
            else
            {
                TempData["error"] = "Formulaire invalide";
                return View(form);
            }
        }
    }
}
