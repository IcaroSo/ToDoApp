using Microsoft.EntityFrameworkCore;

namespace ToDoApplication.Models;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext() { }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Task> Tasks { get; set; }
    public virtual DbSet<ToDo> ToDo { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured) // Configurar apenas se não houver um provedor configurado
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=auth_database;Username=user;Password=12345");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
