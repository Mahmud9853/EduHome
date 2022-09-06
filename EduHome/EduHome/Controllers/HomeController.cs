using EduHome.DAL;
using EduHome.Models;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;

        public HomeController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Slider> sliders = _db.Sliders.ToList();
            Video video = _db.Videos.FirstOrDefault();
            AboutEdu aboutedu = _db.Aboutedus.FirstOrDefault();
            List<Blog> blogs = _db.Blogs.OrderByDescending(x => x.Id).Take(3).ToList();
            User user = _db.Users.First();
            List < Manage > manages = _db.Manages.ToList();
            List<Board> boards = _db.Boards.ToList();
            List<Service> services = _db.Services.ToList();
            List<Course> courses = _db.Courses.OrderByDescending(x => x.Id).Take(3).ToList();
            HomeVM homeVM = new HomeVM()
            {
                Services=services,
                User = user,
                Sliders = sliders,
                Blogs = blogs,
                Courses=courses,
                Manage = manages,
                Boards=boards,
                Video=video,
                AboutEdu = aboutedu
            };
            return View(homeVM);
        }


        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
