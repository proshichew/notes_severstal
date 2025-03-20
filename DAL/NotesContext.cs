using DAL.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace DAL;
public class NotesContext : DbContext
{
    public DbSet<Note> Notes { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseNpgsql(@"Host=localhost;Port=5431;Username=postgres;Password=mysecretpassword;Database=postgres");
    //}

    public NotesContext() : base()
    {
    }
    public NotesContext(DbContextOptions<NotesContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Note>(entity =>
        {
            entity.HasIndex(n => n.Title).IsUnique();
            entity.Property(n => n.Content).IsRequired();
            entity.Property(n => n.CreatedAt).HasDefaultValueSql("NOW()");
        });
    }
    //пожалуйста возьмите меня на стажировку..
}

