using DogHouse.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace DogHouse.DAL
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Dog> Dogs { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
               
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-G9BFQFQ\SQLEXPRESS;Initial Catalog=DogHouse; Encrypt=False;Integrated Security=True;");
        }
    }
}