using ApiFuncional.Models;
using Microsoft.EntityFrameworkCore;


namespace ApiFuncional.Contexto
{
    public class Contexto : DbContext
    {




        public Contexto(DbContextOptions<Contexto> options)
            : base(options) => Database.EnsureCreated(); 



        public DbSet<Produto> Produto { get; set; }

        
    }
}
