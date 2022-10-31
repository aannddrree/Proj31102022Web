using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proj31102022Web.Models;

namespace Proj31102022Web.Data
{
    public class Proj31102022WebContext : DbContext
    {
        public Proj31102022WebContext (DbContextOptions<Proj31102022WebContext> options)
            : base(options)
        {
        }

        public DbSet<Proj31102022Web.Models.Bruxa> Bruxa { get; set; }
    }
}
