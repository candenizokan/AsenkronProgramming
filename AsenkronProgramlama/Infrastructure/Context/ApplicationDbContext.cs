using AsenkronProgramlama.Models.Entities.Concrete;
using AsenkronProgramlama.Models.Mapping;
using Microsoft.EntityFrameworkCore;

namespace AsenkronProgramlama.Infrastructure.Context
{
    public class ApplicationDbContext:DbContext
    {

        //startupta konuşturmak için ctorda connectionstring 

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        //ayağa kalkmasını istediğim tabloları db sette yapıyorum
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        //konfigurayonlarım var

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMapping());
            base.OnModelCreating(modelBuilder);
        }

    }
}
