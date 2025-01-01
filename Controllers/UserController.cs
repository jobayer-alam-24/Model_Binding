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
        private List<User> _users = new List<User>
        {
            new User { Id = 1, Name = "Alice", Email = "alice@example.com", Password = "password123", Mobile = "1234567890", Gender = "Female", Country = "USA", DateOfBirth = new DateTime(1995, 5, 1), Hobbies = new List<string> { "Reading", "Traveling" }, TermsAccepted = true },
            new User { Id = 2, Name = "Bob", Email = "bob@example.com", Password = "password123", Mobile = "2345678901", Gender = "Male", Country = "Canada", DateOfBirth = new DateTime(1992, 6, 15), Hobbies = new List<string> { "Cycling", "Music" }, TermsAccepted = true },
            new User { Id = 3, Name = "Charlie", Email = "charlie@example.com", Password = "password123", Mobile = "3456789012", Gender = "Male", Country = "UK", DateOfBirth = new DateTime(1990, 8, 25), Hobbies = new List<string> { "Cooking", "Football" }, TermsAccepted = true },
            new User { Id = 4, Name = "Diana", Email = "diana@example.com", Password = "password123", Mobile = "4567890123", Gender = "Female", Country = "Australia", DateOfBirth = new DateTime(1997, 12, 3), Hobbies = new List<string> { "Painting", "Swimming" }, TermsAccepted = true },
            new User { Id = 5, Name = "Eve", Email = "eve@example.com", Password = "password123", Mobile = "5678901234", Gender = "Female", Country = "Germany", DateOfBirth = new DateTime(1994, 1, 20), Hobbies = new List<string> { "Photography", "Yoga" }, TermsAccepted = true },
            new User { Id = 6, Name = "Frank", Email = "frank@example.com", Password = "password123", Mobile = "6789012345", Gender = "Male", Country = "France", DateOfBirth = new DateTime(1989, 11, 18), Hobbies = new List<string> { "Running", "Music" }, TermsAccepted = true },
            new User { Id = 7, Name = "Grace", Email = "grace@example.com", Password = "password123", Mobile = "7890123456", Gender = "Female", Country = "Italy", DateOfBirth = new DateTime(1996, 9, 30), Hobbies = new List<string> { "Reading", "Jogging" }, TermsAccepted = true },
            new User { Id = 8, Name = "Hank", Email = "hank@example.com", Password = "password123", Mobile = "8901234567", Gender = "Male", Country = "Spain", DateOfBirth = new DateTime(1993, 4, 10), Hobbies = new List<string> { "Gaming", "Traveling" }, TermsAccepted = true },
            new User { Id = 9, Name = "Ivy", Email = "ivy@example.com", Password = "password123", Mobile = "9012345678", Gender = "Female", Country = "Netherlands", DateOfBirth = new DateTime(1998, 7, 13), Hobbies = new List<string> { "Dancing", "Cooking" }, TermsAccepted = true },
            new User { Id = 10, Name = "Jack", Email = "jack@example.com", Password = "password123", Mobile = "0123456789", Gender = "Male", Country = "USA", DateOfBirth = new DateTime(1991, 3, 5), Hobbies = new List<string> { "Cycling", "Gaming" }, TermsAccepted = true }
        };
        public IActionResult List()
        {
            return View(_users);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = new User();
            ViewBag.Countries = new List<string> { "United States", "Canada", "United Kingdom", "Australia", "India" };
            ViewBag.Hobbies = new List<string> { "Reading", "Traveling", "Gaming", "Cooking" };
            return View(model);
        }
        public ActionResult Details(int id)
        {
            if(id <= 0)
                return NotFound("Invalid ID");
            var user = _users.FirstOrDefault(u => u.Id == id);
            return new JsonResult(user);
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