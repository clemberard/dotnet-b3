
using Microsoft.EntityFrameworkCore;
using mvc.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace mvc.Data;

public class ApplicationDbContext : IdentityDbContext
{
    //public DbSet<Teacher> Teachers { get; set; }

    public DbSet<Student> Students { get; set; }

    public DbSet<Teacher> Teachers { get; set; }

    public DbSet<Event> Events { get; set; }

    public DbSet<Account> Accounts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Teacher>().ToTable("Teacher");
        modelBuilder.Entity<Student>().ToTable("Student");
        modelBuilder.Entity<Event>().ToTable("Event");
        modelBuilder.Entity<Account>().ToTable("Account");
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
}