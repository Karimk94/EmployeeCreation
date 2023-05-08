using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Domain.Data
{
    public class DBContext : DbContext, IDBContext
    {
        public DBContext(DbContextOptions<DBContext> options)
      : base(options)
        { }
        public DbSet<Employee> Employee { get ; set ; }
    }
}
