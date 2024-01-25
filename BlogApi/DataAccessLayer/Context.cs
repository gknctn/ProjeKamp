using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BlogApi.DataAccessLayer
{
    public class Context:DbContext
    {
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlServer("server=GOKHAN\\SQLEXPRESS;database=BlogApiDb;integrated security=true");
        }
        public DbSet<Employee> Employees{ get; set; }
    }
}
