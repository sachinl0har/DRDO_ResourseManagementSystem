using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DRDO_ResourseManagementSystem.Models;

namespace DRDO_ResourseManagementSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<DRDO_ResourseManagementSystem.Models.Room> Room { get; set; }
        public DbSet<DRDO_ResourseManagementSystem.Models.Book> Book { get; set; }
    }
}