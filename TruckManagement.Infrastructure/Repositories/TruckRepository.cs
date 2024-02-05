using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TruckManagement.Domain.Models;
using TruckManagement.Infrastructure.Contexts;
using TruckManagement.Infrastructure.Entities;

namespace TruckManagement.Infrastructure.Repositories;

/// <inheritdoc />
public class TruckRepository : ITruckRepository
{
    private readonly ILogger<TruckRepository> _logger;

    private IQueryable<TrucksEntity> BaseQuery { get; set; }

    private DbSet<TrucksEntity> DbSet { get; set; }

    private TruckDbContext Context { get; set; }

    private readonly IMapper _mapper;

    public TruckRepository(IMapper mapper, TruckDbContext context, ILogger<TruckRepository> logger)
    {
        _mapper = mapper;
        Context = context;
        _logger = logger;
        DbSet = Context.Set<TrucksEntity>();
        BaseQuery = DbSet.AsNoTracking();
    }
    
    /// <inheritdoc />
    public async Task<List<Truck>> GetTrucksAsync()
    {
        var trucks = await BaseQuery.ToListAsync();
        
        return _mapper.Map<List<Truck>>(trucks);
    }

    /// <inheritdoc />
    public Task<Truck> GetTruckByCodeAsync(string code)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public Task<Truck> AddTruckAsync(Truck truck)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public Task<Truck> UpdateTruckAsync(Truck truck)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public Task DeleteTruckAsync(string code)
    {
        throw new NotImplementedException();
    }
}