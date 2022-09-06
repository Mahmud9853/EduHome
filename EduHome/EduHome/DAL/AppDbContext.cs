using EduHome.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<About> Abouts { get;  set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Manage> Manages { get; set; }
        public DbSet<AboutEdu> Aboutedus { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Board> Boards  { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Bio> Bios  { get; set; }
        public DbSet<Logo> Logos { get; set; }
        public DbSet<Icon> Icons { get; set; }
        public DbSet<Service> Services { get; set; }

    }
}
