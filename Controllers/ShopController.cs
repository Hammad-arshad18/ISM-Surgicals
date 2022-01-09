using _072_HammadArshad_Task1.Data;
using _072_HammadArshad_Task1.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _072_HammadArshad_Task1.Controllers
{
    public class ShopController : Controller
    {
        private readonly IsmDbContext _db;
        public List<Product> products;
        private readonly IWebHostEnvironment _env;
        public ShopController(IsmDbContext db,IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                products = await _db.Products.ToListAsync();
                return View(products);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        public async Task<IActionResult> Shopnow(int ? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            Product DetailProduct = await _db.Products.FirstOrDefaultAsync(x => x.Id == Id);
            if (DetailProduct == null)
            {
                return NotFound();
            }
            return View(DetailProduct);
        }
        public async Task<IActionResult> ShopEdit(int ? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            Product EditProduct = await _db.Products.FirstOrDefaultAsync(x => x.Id == Id);
            if (EditProduct == null)
            {
                return NotFound();
            }
            return View(EditProduct);
        }

        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> ShopEdit(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string folder = "images/products/";
                    product.product_image ="/"+ (folder += Guid.NewGuid().ToString() + product.image.FileName);
                    string server_folder = Path.Combine(_env.WebRootPath, folder);
                    using (var filestream=new FileStream(server_folder, FileMode.Create))
                    {
                        await product.image.CopyToAsync(filestream);
                    }
                    Product get_product = await _db.Products.FirstOrDefaultAsync(x => x.Id == product.Id);
                    if (get_product == null)
                    {
                        return NotFound();
                    }
                    get_product.product_name = product.product_name;
                    get_product.product_price = product.product_price;
                    get_product.product_desciption = product.product_desciption;
                    get_product.product_image = product.product_image;
                    _db.Products.Update(get_product);
                    await _db.SaveChangesAsync();
                    return Redirect("/admin");
                }
                return View(await _db.Products.FindAsync(product.Id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IActionResult> ShopDelete(int ? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            Product delete_product = await _db.Products.FirstOrDefaultAsync(x => x.Id == Id);
            if (delete_product == null)
            {
                return NotFound();
            }
            _db.Products.Remove(delete_product);
            await _db.SaveChangesAsync();
            return Redirect("/admin/");
        }
    }
}
