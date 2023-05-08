using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Domain.Interfaces
{
    public interface IDBContext
    {
        DatabaseFacade Database { get; }
        DbSet<Employee> Employee { get; set; }
    }
}
