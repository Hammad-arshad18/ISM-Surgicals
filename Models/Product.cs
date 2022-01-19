using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _072_HammadArshad_Task1.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Product Name Is Required")]
        [DataType(DataType.Text),Display(Name ="Product Name")]
        [StringLength(20,MinimumLength =6)]
        public string product_name { get; set; }

        [Required(ErrorMessage = "Product Price Is Required")]
        [DataType(DataType.Currency), Display(Name = "Product Price")]
        public string product_price { get; set; }

        [Required(ErrorMessage = "Product Decription Is Required")]
        [DataType(DataType.Text), Display(Name = "Product Decription")]
        [StringLength(500,MinimumLength =30)]
        public string product_desciption { get; set; }

        public string product_image { get; set; }

        [Display(Name = "Select Product Image")]
        [NotMapped]
        public IFormFile image { get; set; }

        public int CategoriesId { get; set; }
        public Categories Category { get; set; }
    }
}
