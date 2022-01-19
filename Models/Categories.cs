using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _072_HammadArshad_Task1.Models
{
    public class Categories
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Category Name Is Required")]
        [Display(Name = "Category Name "),StringLength(50,MinimumLength =3)]
        public string Category { get; set; }
        public List<Product> Products { get; set; }
    }
}
