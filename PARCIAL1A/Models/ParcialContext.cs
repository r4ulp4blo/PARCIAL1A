using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using PARCIAL1A.Models;


namespace PARCIAL1A.Models
{
    public class ParcialContext : DbContext
    {
        public ParcialContext(DbContextOptions<ParcialContext> options) : base(options)
        {

        }

        public DbSet<autores> autores { get; set; }

        public DbSet<autoresLibro> autoresLibro { get; set; }

        public DbSet<libros> libros { get; set; }

        public DbSet<posts> posts { get; set; }

    }
}
