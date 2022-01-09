using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _072_HammadArshad_Task1.Models
{
    public class Register
    {
        [Key,Required(ErrorMessage ="Email Address Is Required"), Display(Name ="Email Address")]
        [EmailAddress(ErrorMessage ="Please Enter A Valid Email Address.")]
        public string Email { get; set; }
        [Required(ErrorMessage ="UserName Is Required")]
        [DataType(DataType.Text),Display(Name ="UserName")]
        public string Username { get; set; }
        [Required(ErrorMessage ="Password Is Required"), DataType(DataType.Password)]
        [Display(Name ="Password")]
        [Compare("confirmpassword",ErrorMessage ="Password Does Not Match")]
        public string password { get; set; }
        [Required(ErrorMessage = "Comfirm Password Is Required"), DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string confirmpassword { get; set; }
    }
}
