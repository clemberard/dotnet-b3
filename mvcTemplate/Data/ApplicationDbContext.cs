
using Microsoft.EntityFrameworkCore;
using mvc.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace mvc.Data;

public class ApplicationDbContext : IdentityDbContext<Teacher>
{
    //public DbSet<Teacher> Teachers { get; set; }

    public DbSet<Student> Students { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
}