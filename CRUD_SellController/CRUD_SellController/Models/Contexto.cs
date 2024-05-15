using Microsoft.EntityFrameworkCore;

namespace CRUD_SellController.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options):base(options)
        {

        }

        public DbSet<Produto> Produto { get; set; }   
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Venda> Venda { get; set; }


    }
}
