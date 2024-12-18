using Microsoft.EntityFrameworkCore;

namespace ToDoApplication.Models;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext(){}

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options){}

    public DbSet<User> Users { get; set; }
    public DbSet<Task> Tasks { get; set; }
    public DbSet<ToDo> Todo { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Database=auth_database;Username=user;Password=12345");

    protected override void OnModelCreating(ModelBuilder modelBuilder){OnModelCreatingPartial(modelBuilder);}

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
