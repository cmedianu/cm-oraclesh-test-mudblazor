using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Data.Context;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace Features.Client
{
    public class ClientService
    {
        private readonly IDbContextFactory<AppDbContext> _dbFactory;
        private readonly IMapper _mapper;
        private CancellationTokenSource _cts = new CancellationTokenSource();

        public ClientService(IDbContextFactory<AppDbContext> dbFactory, IMapper mapper)
        {
            _dbFactory = dbFactory;
            _mapper = mapper;
        }

        public async Task<(IEnumerable<ClientDto> Items, int TotalCount)>
            GetClientsAsync(int page, int pageSize, string search, string sortColumn, bool sortDesc, Dictionary<string, string> filters)
        {
            // Cancel any previous operations
            _cts.Cancel();
            _cts = new CancellationTokenSource();
            var token = _cts.Token;

            try
            {
                using var db = await _dbFactory.CreateDbContextAsync(token);

                var query = db.Customers.Include(c => c.Country).AsQueryable();

                // Filtering
                if (!string.IsNullOrWhiteSpace(search))
                {
                    query = query.Where(c =>
                        c.CustFirstName.Contains(search) ||
                        c.CustLastName.Contains(search) ||
                        c.CustCity.Contains(search) ||
                        c.CustEmail.Contains(search));
                }
                if (filters != null)
                {
                    if (filters.TryGetValue("CustGender", out var gender) && !string.IsNullOrWhiteSpace(gender))
                        query = query.Where(c => c.CustGender == gender);
                    if (filters.TryGetValue("CustMaritalStatus", out var marital) && !string.IsNullOrWhiteSpace(marital))
                        query = query.Where(c => c.CustMaritalStatus == marital);
                    if (filters.TryGetValue("CustStateProvince", out var state) && !string.IsNullOrWhiteSpace(state))
                        query = query.Where(c => c.CustStateProvince == state);
                    if (filters.TryGetValue("CountryName", out var country) && !string.IsNullOrWhiteSpace(country))
                        query = query.Where(c => c.Country.CountryName == country);
                    if (filters.TryGetValue("CustYearOfBirthMin", out var yobMin) && decimal.TryParse(yobMin, out var minYob))
                        query = query.Where(c => c.CustYearOfBirth >= minYob);
                    if (filters.TryGetValue("CustYearOfBirthMax", out var yobMax) && decimal.TryParse(yobMax, out var maxYob))
                        query = query.Where(c => c.CustYearOfBirth <= maxYob);
                }

                // Sorting
                query = sortColumn switch
                {
                    "CustId" => sortDesc ? query.OrderByDescending(c => c.CustId) : query.OrderBy(c => c.CustId),
                    "CustFirstName" => sortDesc ? query.OrderByDescending(c => c.CustFirstName) : query.OrderBy(c => c.CustFirstName),
                    "CustLastName" => sortDesc ? query.OrderByDescending(c => c.CustLastName) : query.OrderBy(c => c.CustLastName),
                    "CustYearOfBirth" => sortDesc ? query.OrderByDescending(c => c.CustYearOfBirth) : query.OrderBy(c => c.CustYearOfBirth),
                    "CustCity" => sortDesc ? query.OrderByDescending(c => c.CustCity) : query.OrderBy(c => c.CustCity),
                    "CustGender" => sortDesc ? query.OrderByDescending(c => c.CustGender) : query.OrderBy(c => c.CustGender),
                    "CustMaritalStatus" => sortDesc ? query.OrderByDescending(c => c.CustMaritalStatus) : query.OrderBy(c => c.CustMaritalStatus),
                    "CustStateProvince" => sortDesc ? query.OrderByDescending(c => c.CustStateProvince) : query.OrderBy(c => c.CustStateProvince),
                    "CountryName" => sortDesc ? query.OrderByDescending(c => c.Country.CountryName) : query.OrderBy(c => c.Country.CountryName),
                    "CustEmail" => sortDesc ? query.OrderByDescending(c => c.CustEmail) : query.OrderBy(c => c.CustEmail),
                    _ => query.OrderBy(c => c.CustId)
                };

                // Execute the count and data queries in one database round trip
                var countQuery = query;
                var totalCount = await countQuery.CountAsync(token);

                var dataQuery = query
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ProjectTo<ClientDto>(_mapper.ConfigurationProvider);

                var items = await dataQuery.ToListAsync(token);

                return (items, totalCount);
            }
            catch (OperationCanceledException)
            {
                // Return empty result when canceled
                return (Array.Empty<ClientDto>(), 0);
            }
            catch (Exception)
            {
                // Re-throw other exceptions
                throw;
            }
        }

        public async Task<List<string>> GetGenderOptionsAsync()
        {
            using var db = await _dbFactory.CreateDbContextAsync();
            return await db.Customers
                .Where(c => !string.IsNullOrEmpty(c.CustGender))
                .Select(c => c.CustGender)
                .Distinct()
                .OrderBy(g => g)
                .ToListAsync();
        }

        public async Task<List<string>> GetMaritalStatusOptionsAsync()
        {
            using var db = await _dbFactory.CreateDbContextAsync();
            return await db.Customers
                .Where(c => !string.IsNullOrEmpty(c.CustMaritalStatus))
                .Select(c => c.CustMaritalStatus)
                .Distinct()
                .OrderBy(m => m)
                .ToListAsync();
        }

        public async Task<List<string>> GetStateProvinceOptionsAsync()
        {
            using var db = await _dbFactory.CreateDbContextAsync();
            return await db.Customers
                .Where(c => !string.IsNullOrEmpty(c.CustStateProvince))
                .Select(c => c.CustStateProvince)
                .Distinct()
                .OrderBy(s => s)
                .ToListAsync();
        }

        public async Task<List<(decimal CountryId, string CountryName)>> GetCountryOptionsAsync()
        {
            using var db = await _dbFactory.CreateDbContextAsync();
            return (await db.Countries
                .Select(c => new { c.CountryId, c.CountryName })
                .OrderBy(c => c.CountryName)
                .ToListAsync())
                .Select(c => (c.CountryId, c.CountryName))
                .ToList();
        }

        public async Task<ClientDto> GetClientByIdAsync(decimal id)
        {
            using var db = await _dbFactory.CreateDbContextAsync();
            var entity = await db.Customers.Include(c => c.Country).FirstOrDefaultAsync(c => c.CustId == id);
            return entity == null ? null : _mapper.Map<ClientDto>(entity);
        }

        public async Task<bool> UpdateClientAsync(ClientDto dto)
        {
            if (dto.CustId == null)
                return false;
            using var db = await _dbFactory.CreateDbContextAsync();
            var entity = await db.Customers.FirstOrDefaultAsync(c => c.CustId == dto.CustId);
            if (entity == null) return false;
            _mapper.Map(dto, entity);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<decimal> CreateClientAsync(ClientDto dto)
        {
            using var db = await _dbFactory.CreateDbContextAsync();
            var entity = _mapper.Map<Data.Entities.Customer>(dto);
            // Ensure CustId is not set for new entities
            entity.CustId = default;
            db.Customers.Add(entity);
            await db.SaveChangesAsync();
            return entity.CustId;
        }
    }
} 