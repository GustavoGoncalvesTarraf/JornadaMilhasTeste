using JornadaMilhasV1.Modelos;
using Microsoft.EntityFrameworkCore;

namespace JornadaMilhas.Dados
{
    public class JornadasMilhasContext : DbContext
    {
        public DbSet<OfertaViagem> OfertasViagem { get; set; }  
        public DbSet<Rota> Rotas { get; set; }
        public JornadasMilhasContext()
        {
            
        }

        public JornadasMilhasContext(DbContextOptions<JornadasMilhasContext> options): base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=JornadaMilhas;User Id=sa;Password=1234; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rota>().HasKey(e => e.Id);
            modelBuilder.Entity<Rota>()
                .Property(a => a.Origem);
            modelBuilder.Entity<Rota>()
                .Property(a => a.Destino);
            modelBuilder.Entity<Rota>().Ignore(a => a.Erros);
            modelBuilder.Entity<Rota>().Ignore(a => a.EhValido);

            modelBuilder.Entity<OfertaViagem>().HasKey(e => e.Id);
            modelBuilder.Entity<OfertaViagem>()
                .OwnsOne(o => o.Periodo, periodo =>
                {
                    periodo.Property(e => e.DataInicial).HasColumnName("DataInicial");
                    periodo.Property(e => e.DataFinal).HasColumnName("DataFinal");
                    periodo.Ignore(e => e.Erros);
                    periodo.Ignore(e => e.EhValido);
                });

            modelBuilder.Entity<OfertaViagem>().Property(o => o.Preco);
            modelBuilder.Entity<OfertaViagem>().Ignore(a => a.Erros);
            modelBuilder.Entity<OfertaViagem>().Ignore(a => a.EhValido);

            base.OnModelCreating(modelBuilder);
        }
    }
}
