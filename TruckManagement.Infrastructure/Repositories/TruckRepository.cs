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

    /// <summary>
    /// Default constructor for TruckRepository.
    /// </summary>
    /// <param name="mapper">Mapper instance.</param>
    /// <param name="context">DB Context instance.</param>
    /// <param name="logger">Logger instance.</param>
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
    public async Task<Truck?> GetTruckByCodeAsync(string code)
    {
        var truck = await BaseQuery.FirstOrDefaultAsync(x => x.Code == code);
        
        return _mapper.Map<Truck>(truck);
    }
    /// <inheritdoc />
    public async Task<TruckDto?> GetTruckDtoByCodeAsync(string code)
    {
        var truck = await BaseQuery.FirstOrDefaultAsync(x => x.Code == code);
        
        return _mapper.Map<TruckDto>(truck);
    }

    /// <inheritdoc />
    public async Task<Truck?> AddTruckAsync(Truck truck)
    {
        var truckEntity = _mapper.Map<TrucksEntity>(truck);
        truckEntity.Id = Guid.NewGuid();

        await DbSet.AddAsync(truckEntity);
        var saveProcess = await Context.SaveChangesAsync();
        
        if(saveProcess > 0)
            return _mapper.Map<Truck>(truckEntity);

        return null;
    }

    /// <inheritdoc />
    public async Task<Truck?> UpdateTruckAsync(Truck truck)
    {
        var existingTruck = await GetTruckDtoByCodeAsync(truck.Code);
        
        if(existingTruck == null)
            return null;
        
        var requestEntity = _mapper.Map<TruckDto>(truck);
        requestEntity.Id = existingTruck.Id;
        DbSet.Update(_mapper.Map<TrucksEntity>(requestEntity));
        var saveProcess = await Context.SaveChangesAsync();
        
        if(saveProcess > 0)
            return _mapper.Map<Truck>(requestEntity);
        
        return null;
    }

    /// <inheritdoc />
    public async Task<bool> DeleteTruckAsync(string code)
    {
        var existingTruck = await GetTruckDtoByCodeAsync(code);
        
        if(existingTruck == null)
            return false;
        
        DbSet.Remove(_mapper.Map<TrucksEntity>(existingTruck));
        var saveProcess = await Context.SaveChangesAsync();
        
        if(saveProcess > 0)
            return true;
        
        return false;
    }
}