using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model_Binding.Models;

namespace Model_Binding.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            var model = new User();
            ViewBag.Countries = new List<string> { "United States", "Canada", "United Kingdom", "Australia", "India" };
            ViewBag.Hobbies = new List<string> { "Reading", "Traveling", "Gaming", "Cooking" };
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(
            [FromForm(Name = "Name")] string UserName,
            [FromForm(Name = "Email")] string UserEmail,
            [FromForm] string Password,
            [FromForm] string Mobile,
            [FromForm] string Gender,
            [FromForm] string Country,
            [FromForm] DateTime DateOfBirth,
            [FromForm] bool TermsAccepted
        )
        {
            var user = new User()
            {
                Name = UserName,
                Email = UserEmail,
                Password = Password,
                Mobile = Mobile,
                Gender = Gender,
                Country = Country,
                DateOfBirth = DateOfBirth,
                TermsAccepted = TermsAccepted
            };
            if(!ModelState.IsValid)
            {
                ViewBag.Countries = new List<string> { "United States", "Canada", "United Kingdom", "Australia", "India" };
                ViewBag.Hobbies = new List<string> { "Reading", "Traveling", "Gaming", "Cooking" };
                return View(user);
            }
            return RedirectToAction("Success", user);
        }
        [HttpGet]
        public IActionResult Success(User model)
        {
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}