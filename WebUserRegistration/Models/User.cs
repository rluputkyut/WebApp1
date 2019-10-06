using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUserRegistration.Models
{
    public class User
    {
        [Key]
        [Display(Name = "No")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string RegisteredDate { get; set; }
        public string EventDays { get; set; }
        public string AddationalRequest { get; set; }

    }
}
