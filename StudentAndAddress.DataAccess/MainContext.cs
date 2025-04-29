using Microsoft.EntityFrameworkCore;
using StudentAndAddress.DataAccess.Entities;

namespace StudentAndAddress.DataAccess;

public class MainContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<User> Users { get; set; }

    public MainContext(DbContextOptions<MainContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>()
            .HasOne(p => p.Address)
            .WithOne(p => p.Student)
            .HasForeignKey<Address>(p => p.StudentId);
        base.OnModelCreating(modelBuilder);
    }
}
