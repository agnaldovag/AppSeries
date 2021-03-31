using CadSeries.Models;
using Microsoft.EntityFrameworkCore;

namespace CadSeries.Dados
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options)
        : base(options)
        {
        }
        public DbSet<TV> TVs { get; set; }
        public DbSet<Diretor> Diretor { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<Genero> Genero { get; set; }
    }
}
