﻿using Microsoft.EntityFrameworkCore;
using ProjectClientServer.Contexts;
using ProjectClientServer.Models;
using ProjectClientServer.Repositories.Contract;

namespace ProjectClientServer.Repositories.Data
{
    public class UniversityRepository : GeneralRepository<University, int, MyContext>, IUniversityRepository
    {
        
        public UniversityRepository(MyContext context) : base(context)
        {
        }

        public async Task<University?> GetByNameAsync(string name)
        {
            return await _context.Set<University>().FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<bool> IsNameExistAsync(string name)
        {
            return await _context.Set<University>().AnyAsync(x => x.Name == name);
        }

        public override async Task<University?> InsertAsync(University entity)
        {
            if (await IsNameExistAsync(entity.Name))
            {
                return await GetByNameAsync(entity.Name);
            }
            return await base.InsertAsync(entity);
        }

        
    }
}
