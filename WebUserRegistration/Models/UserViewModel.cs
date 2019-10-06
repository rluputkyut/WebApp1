using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUserRegistration.Models
{
    public class UserViewModel
    {
        [Required]
        [Display(Name = "Name")]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Email")]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Gender { get; set; }

        [DataType(DataType.Date)]
        [Range(typeof(DateTime), "01/01/2019", "01/06/2019")]
        public DateTime RegisteredDate { get; set; }

        public bool Day1 { get; set; }
        public bool Day2 { get; set; }
        public bool Day3 { get; set; }

        [StringLength(100)]
        public string AddationalRequest { get; set; }
    }
}
