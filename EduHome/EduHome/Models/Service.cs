using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Service
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="section doldurun")]
        public string Name { get; set; }
        public string Title { get; set; }
        public  bool IsDeactive { get; set; }

    }
}
