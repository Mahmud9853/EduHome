using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class CoursesController : Controller
    {
        private readonly AppDbContext _db;
        public CoursesController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            ViewBag.Coursescount = _db.Courses.Count();
            List<Course> courses = _db.Courses.OrderByDescending(x => x.Id).Take(6).ToList();
            return View(courses);
        }
        public IActionResult CourseLoad(int skip)
        {
            if (_db.Courses.Count()<=skip)
            {
                return Content("Daxil olmaq qadağandır! ");
            }
            List<Course> courses = _db.Courses.OrderByDescending(x => x.Id).Skip(skip).Take(6).ToList();
            return PartialView("_CourseLoad", courses);
        }
    }
}
