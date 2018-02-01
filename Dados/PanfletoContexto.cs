using Microsoft.EntityFrameworkCore;
using PanfletoCursos.Models;

namespace PanfletoCursos.Dados
{
    public class PanfletoContexto : DbContext
    {
        public PanfletoContexto(DbContextOptions<PanfletoContexto> options) : base(options) { }
        public DbSet<Area> Area { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<Turma> Turma { get; set; }
        //eu preciso ter acesso a esse cara, tanto pra mandar um 
        //dado quanto pra tirar um dado de dentro dele, dessa base virtual.

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        //override altera/sobrepoe qualquer método. nesse caso, ele está sobrepondo o OnModelCreating
        {
            modelBuilder.Entity<Area>().ToTable("Area");
            modelBuilder.Entity<Curso>().ToTable("Curso");
            modelBuilder.Entity<Turma>().ToTable("Turma");
        }
    }
}