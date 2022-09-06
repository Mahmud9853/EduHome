using EduHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewModels
{
    public class HomeVM
    {
        public List<Slider> Sliders { get; set; }
        public AboutEdu AboutEdu { get; set; }
        public User User { get; set; }
        public List<Manage> Manage { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<Course> Courses { get; set; }
        public List<Board> Boards { get; set; }
        public Video Video { get; set; }
        public List<Service> Services { get; set; }
    }
}
