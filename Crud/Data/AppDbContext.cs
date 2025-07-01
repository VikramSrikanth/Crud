using Crud.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }



        public virtual DbSet<user> Usertables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Data Source=LTIN603354;Initial Catalog=onlineExam;Trust Server Certificate=True;Integrated Security =True");
        // => optionsBuilder.UseSqlServer("DefaultConnectionString");


    }
}
