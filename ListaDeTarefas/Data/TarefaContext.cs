using ListaDeTarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace ListaDeTarefas.Data;

public class TarefaContext : DbContext
{
    public TarefaContext(DbContextOptions<TarefaContext> options)
        : base(options)
    {
        
    }
    public DbSet<Tarefa> Tarefas { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tarefa>()
            .HasKey(t => t.Id);
    }
}