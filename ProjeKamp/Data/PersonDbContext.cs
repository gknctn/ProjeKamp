using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjeKamp.Models;

namespace ProjeKamp.Data
{
    public class PersonDbContext : DbContext
    {
        public PersonDbContext (DbContextOptions<PersonDbContext> options)
            : base(options)
        {
        }

        public DbSet<ProjeKamp.Models.Person> Person { get; set; }
    }
}
