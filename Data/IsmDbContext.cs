using _072_HammadArshad_Task1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _072_HammadArshad_Task1.Data
{
    public class IsmDbContext : IdentityDbContext
    {
        public IsmDbContext(DbContextOptions<IsmDbContext> options) : base(options)
        {

        }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<_072_HammadArshad_Task1.Models.Login> Login { get; set; }
        public DbSet<_072_HammadArshad_Task1.Models.Categories> Categories { get; set; }
    }
}
