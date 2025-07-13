using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Data.Entities;
using Data.Context;
using Features.Country;
using AutoMapper;

namespace Features.Country
{
    public class CountryService
    {
        private readonly IDbContextFactory<AppDbContext> _dbFactory;
        private readonly IMapper _mapper;

        public CountryService(IDbContextFactory<AppDbContext> dbFactory, IMapper mapper)
        {
            _dbFactory = dbFactory;
            _mapper = mapper;
        }

        public async Task<List<CountryDto>> GetAllAsync()
        {
            using var db = _dbFactory.CreateDbContext();
            var countries = await db.Countries.ToListAsync();
            return _mapper.Map<List<CountryDto>>(countries);
        }

        public async Task<CountryDto> GetByIdAsync(decimal id)
        {
            using var db = _dbFactory.CreateDbContext();
            var country = await db.Countries.FindAsync(id);
            return _mapper.Map<CountryDto>(country);
        }

        public async Task<CountryDto> CreateAsync(CountryDto dto)
        {
            using var db = _dbFactory.CreateDbContext();
            var entity = _mapper.Map<Data.Entities.Country>(dto);
            db.Countries.Add(entity);
            await db.SaveChangesAsync();
            return _mapper.Map<CountryDto>(entity);
        }

        public async Task<CountryDto> UpdateAsync(CountryDto dto)
        {
            using var db = _dbFactory.CreateDbContext();
            var entity = await db.Countries.FindAsync(dto.CountryId);
            if (entity == null) return null;
            _mapper.Map(dto, entity);
            await db.SaveChangesAsync();
            return _mapper.Map<CountryDto>(entity);
        }

        public async Task<bool> DeleteAsync(decimal id)
        {
            using var db = _dbFactory.CreateDbContext();
            var entity = await db.Countries.FindAsync(id);
            if (entity == null) return false;
            db.Countries.Remove(entity);
            await db.SaveChangesAsync();
            return true;
        }
    }
} 