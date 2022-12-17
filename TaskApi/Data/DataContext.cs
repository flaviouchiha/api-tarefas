using Microsoft.EntityFrameworkCore;
using TaskApi.Models;

namespace TaskApi.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("DB_Tasks");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Tarefa>()
                .HasKey(x => x.Codigo);

            modelBuilder
                .Entity<Tarefa>()
                .Property(x => x.Codigo)
                .IsRequired();

            modelBuilder
                .Entity<Tarefa>()
                .Property(x => x.Descricao)
                .IsRequired();

            modelBuilder
                .Entity<Tarefa>()
                .Property(x => x.Status)
                .IsRequired();
        }
    }
}