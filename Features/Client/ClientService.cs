using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Data.Context;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace Features.Client
{
    public class ClientService
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public ClientService(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<(IEnumerable<ClientDto> Items, int TotalCount)>
            GetClientsAsync(int page, int pageSize, string search, string sortColumn, bool sortDesc, Dictionary<string, string> filters)
        {
                var query = _db.Customers.Include(c => c.Country).AsQueryable();

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

            var totalCount = await query.CountAsync();
            var items = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<ClientDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return (items, totalCount);
        }
    }
} 