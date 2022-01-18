using _072_HammadArshad_Task1.Data;
using _072_HammadArshad_Task1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace _072_HammadArshad_Task1.Controllers
{
    public class HomeController : Controller
    {
        IsmDbContext _db;
        public HomeController(IsmDbContext dbContext)
        {
            _db = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _db.Products.Take(4).ToListAsync());
        }
        public IActionResult Contact()
        {
            ViewBag.formsubmit = false;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contact(Contact contact)
        {
            if (contact.agreement == "on")
            {
                ViewBag.name = contact.uname;
                ViewBag.email = contact.uemail;
                ViewBag.phone = contact.uphone;
                ViewBag.gender = contact.gender;
                ViewBag.feedback = contact.ofeedback;
                ViewBag.formsubmit = true;
                if (ModelState.IsValid)
                {
                    await _db.AddAsync(contact);
                    await _db.SaveChangesAsync();
                }
            }
            return View();
        }
        public IActionResult About()
        {
            ViewBag.name = "My Name is Hammad Arshad & I'm ";
            return View();
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}
