using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using VetPet.Models;

namespace VetPet.Database.VetContext
{
    public class VetContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }

        public VetContext(DbContextOptions<VetContext> options): base(options)
        {

        }
    }
}
