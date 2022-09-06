using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string By { get; set; }
        public string Title { get; set; }
        public DateTime Createtime { get; set; }
        public string Image { get; set; }
    }
}
