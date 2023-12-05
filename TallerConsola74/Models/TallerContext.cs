using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerConsola74.Models
{
    public class TallerContext: DbContext
    {
        public TallerContext(DbContextOptions<TallerContext> options)
            : base(options)
        {

        }

        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Curso> Cursos { get; set; }
    }
}
