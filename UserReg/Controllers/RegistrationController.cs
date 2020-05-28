using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
///using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserReg.Models;

namespace UserReg.Controllers
{
    public class RegistrationController:Controller
    {
        private readonly ApplicationUser _auc;

        public RegistrationController(ApplicationUser auc)
        {
            _auc = auc;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User uc)
        {
            _auc.Add(uc);
            _auc.SaveChanges();
            ViewBag.message = "The user " + uc.Username + " is saved successfully";
            return View();
        }
        }
}
