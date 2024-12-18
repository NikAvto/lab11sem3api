using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary1
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<EmployeeTerritories> EmployeeTerritories { get; set; }
    }
}

public class EmployeeTerritories
{
    [Key]
    public int EmployeeID { get; set; }
    public string TerritoryID { get; set; }
}
