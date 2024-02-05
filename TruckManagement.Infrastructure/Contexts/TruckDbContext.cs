using Microsoft.EntityFrameworkCore;
using TruckManagement.Infrastructure.Entities;

namespace TruckManagement.Infrastructure.Contexts;

public class TruckDbContext : DbContext
{
    public TruckDbContext(DbContextOptions<TruckDbContext> options) : base(options)
    {
    }

    public DbSet<TrucksEntity> TrucksEntity { get; set; }
    

}