using CloudComputingHomeworkApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CloudComputingHomeworkApp.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Person> Persons => Set<Person>();
}
