using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _072_HammadArshad_Task1.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Required, StringLength(maximumLength:30),Display(Name ="Full Name")]
        public string uname { get; set; }
        [Required, Display(Name = "Email Address")]
        [EmailAddress, RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public string uemail { get; set; }
        [Required, Display(Name = "Phone Number")]
        [Phone]
        public string uphone { get; set; }
        [Required]
        public string gender { get; set; }
        [Required(ErrorMessage = "Feedback Field is Required"), Display(Name = "Select type of Feedback")]
        public string ofeedback { get; set; }
        [Required(ErrorMessage ="Agreement Field is Required"), Display(Name = "Do You Want To Submit This Form")]
        public string agreement { get; set; }
    }
}
