using Microsoft.EntityFrameworkCore;
using MyPractice.Models.Entities;

namespace MyPractice.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<MyPrac> MyPracs { get; set; }
    }
}
