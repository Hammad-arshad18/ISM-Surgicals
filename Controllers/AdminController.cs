using _072_HammadArshad_Task1.Data;
using _072_HammadArshad_Task1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _072_HammadArshad_Task1.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IsmDbContext _db;
        public List<Contact> Contact_list;
        public List<Product> Product_list;
        private readonly IWebHostEnvironment _env;

        public AdminController(IsmDbContext ismDbContext, IWebHostEnvironment env)
        {
            _env = env;
            _db = ismDbContext;
        }
        public IActionResult Index()
        {
            try
            {
                Contact_list = _db.Contacts.ToList();
                Product_list = _db.Products.ToList();
                var ModelsTuple = new Tuple<List<Contact>, List<Product>>(Contact_list, Product_list);
                return View(ModelsTuple);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public async Task<IActionResult> Update(int ? Id)
        {
            try
            {
                Contact Contact_update = await _db.Contacts.FindAsync(Id);
                if (Contact_update != null)
                {
                    return View(Contact_update);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Contact contact)
        {
            try
            {
                Contact UserContact = await _db.Contacts.FindAsync(contact.Id);
                if (UserContact != null)
                {
                    if (ModelState.IsValid)
                    {
                        UserContact.uname = contact.uname;
                        UserContact.uemail = contact.uemail;
                        UserContact.uphone = contact.uphone;
                        UserContact.gender = contact.gender;
                        UserContact.ofeedback = contact.ofeedback;
                        _db.Contacts.Update(UserContact);
                        await _db.SaveChangesAsync();
                        return RedirectToAction("index");
                    }
                }
                return View(UserContact);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IActionResult> ViewContact(int ? Id)
        {
            try
            {
                Contact ViewContact = await _db.Contacts.FindAsync(Id);
                if (ViewContact != null)
                {
                    return View(ViewContact);
                }
                return RedirectToAction("index");
            }
            catch (Exception)
            {
                throw;
            }   
        }

        public async Task<IActionResult> Delete(int ? Id)
        {
            if (Id != null)
            {
                Contact DeleteContact = await _db.Contacts.FindAsync(Id);
                if (DeleteContact != null)
                {
                    return View(DeleteContact);
                }
                else
                {
                    return NotFound();
                }
            }
            return RedirectToAction("index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {
                Contact del_con = await _db.Contacts.FindAsync(Id);
                if (del_con != null)
                {
                    _db.Contacts.Remove(del_con);
                    await _db.SaveChangesAsync();
                    return RedirectToAction("index");
                }
       
            return RedirectToAction("index");
        }

        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                string folder = "images/products/";
                product.product_image = "/"+(folder += Guid.NewGuid().ToString() + product.image.FileName);
                string server_folder = Path.Combine(_env.WebRootPath, folder);
                using (var filestream=new FileStream(server_folder, FileMode.Create))
                {
                    await product.image.CopyToAsync(filestream);
                }  
                await _db.Products.AddAsync(product);
                await _db.SaveChangesAsync();
                ModelState.Clear();
            }
            return View();
        }
    }
}
