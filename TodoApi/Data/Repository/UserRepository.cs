using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Core.Entities;

namespace TodoApi.Data.Repository
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(AppDbContext dbContext): base(dbContext)
        {

        }

        public override async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _table.AsNoTracking().Include(u => u.Tasks).ToListAsync();
        }

        public override async Task<User> GetByIdAsync(int id)
        {
            return await _table.AsNoTracking().Include(u => u.Tasks).FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
