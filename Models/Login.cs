using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _072_HammadArshad_Task1.Models
{
    public class Login
    {
        [Key,Required(ErrorMessage ="UserName Is Required"),Display(Name ="UserName")]
        public string username { get; set; }
        [Required(ErrorMessage = "Password Is Required"), Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Display(Name ="Remember Me")]
        public bool remember { get; set; }
    }
}
